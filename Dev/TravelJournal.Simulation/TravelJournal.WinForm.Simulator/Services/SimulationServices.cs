using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelJournal.PCL;
using TravelJournal.PCL.DataService;
using TravelJournal.WinForm.Simulator.Controls;

namespace TravelJournal.WinForm.Simulator
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SimulationServices : ISimulationServices
    {
        private const long THRESHOLD_EXECUTION_WARNING = 10;
        private const long THRESHOLD_EXECUTION_DANGER = 20;
        private const long THRESHOLD_EXECUTION_FAILURE = 25;

        private TravelSimulator simulator;
        private ConnectionTestData testData;

        private System.Threading.Timer operationMonitorTimer;

        public SimulationServices(TravelSimulator simulator)
        {
            this.simulator = simulator;
        }

        #region Private members
        private void AgentInvokeTimeout()
        {
            TravelJournalSimulation.Log(LogType.Error, "Agent started but not returning...");
            TravelJournalSimulation.UpdateInfoInspector(new Dictionary<string, object>() { { "Waiting for agent", false } });
        } 
        #endregion

        // Services implementations

        #region Connection services

        public bool Connect(string deviceName)
        {
            if (simulator.IsConnected == false)
            {
                simulator.IsConnected = true;
                // Monitor
                operationMonitorTimer = new System.Threading.Timer((e) =>
                {
                    AgentInvokeTimeout();
                }, null, Timeout.Infinite, Timeout.Infinite);
                // Log
                TravelJournalSimulation.Log(LogType.Info, string.Format("Device {0} is  connected...", deviceName));
            }
            else
                TravelJournalSimulation.Log(LogType.Warning, string.Format("Device {0} is either already connected... ", deviceName));
            return simulator.IsConnected;
        }
        public bool Disconnect(string deviceName)
        {
            if (simulator.IsConnected == true)
            {
                simulator.IsConnected = false;
                // Monitor
                operationMonitorTimer.Change(Timeout.Infinite, Timeout.Infinite);
                TravelJournalSimulation.UpdateInfoInspector(new Dictionary<string, object>() { { "Waiting for agent", false } });
                operationMonitorTimer = null;
                // Log
                TravelJournalSimulation.Log(LogType.Info, string.Format("Device {0} is disconnected...", deviceName));
            }
            else
                TravelJournalSimulation.Log(LogType.Warning, string.Format("Device {0} is either disconnected... or offline", deviceName));
            return simulator.IsConnected;
        } 

        #endregion
        
        #region Connectivity test services

        public void PrepareTestData(int size)
        {
            testData = CreateTestData(size);
        }
        public ConnectionTestData GetTestData()
        {
            // Pure download operation
            TravelJournalSimulation.Log(LogType.Info, "Querying test data...");
            return testData;
        }
        private ConnectionTestData CreateTestData(int size)
        {
            ConnectionTestData testData = new ConnectionTestData();
            testData.Data = new List<int>();
            for (int i = 0; i < size; i++)
                testData.Data.Add(i);
            return testData;
        }

        #endregion
        
        #region Diagnostic members

        public void NotifyOperationStart()
        {
            operationMonitorTimer.Change(THRESHOLD_EXECUTION_FAILURE * 1000, Timeout.Infinite);
            TravelJournalSimulation.UpdateInfoInspector(new Dictionary<string, object>() { {"Waiting for agent",true}});
            TravelJournalSimulation.Log(LogType.Info, "Periodic agent is invoking...");
        }
        public void ReportExecutionTime(decimal latency)
        {
            TravelJournalSimulation.UpdateConnectionViewer(latency);
            if (latency > THRESHOLD_EXECUTION_DANGER)
                TravelJournalSimulation.Log(LogType.Error, string.Format("Client query latency {0}s surpassed {1}s...", latency.ToString("#.##"), THRESHOLD_EXECUTION_DANGER.ToString("#.##")));
            else if (latency > THRESHOLD_EXECUTION_WARNING)
                TravelJournalSimulation.Log(LogType.Warning, string.Format("Client query latency {0}s surpassed {1}s...",latency.ToString("#.##"),THRESHOLD_EXECUTION_WARNING.ToString("#.##")));
            // Reset execution time monitor
            operationMonitorTimer.Change(Timeout.Infinite, Timeout.Infinite);
            TravelJournalSimulation.UpdateInfoInspector(new Dictionary<string, object>() { { "Waiting for agent", false } });
        }
        public void Log(LogType type, string log, [CallerMemberName] string callerName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLine = -1)
        {
            TravelJournalSimulation.Log(type, log, callerName, callerFilePath, callerLine);
        }
        public void UpdateInfoInspector(Dictionary<string, object> infos)
        {
            TravelJournalSimulation.UpdateInfoInspector(infos);
        }
        public void UpdatePhotoTreeView(List<Album> albums)
        {
            TravelJournalSimulation.UpdatePhotoTreeViewer(albums);
        }

        #endregion

        #region Core services

        public GpsPoint GetCurrentGps()
        {
            // Log 
            TravelJournalSimulation.Log(LogType.HighlightInfo, "Querying current position ...");
            // Get current gps
            return simulator.GetCurrentGps();
        }
        public IEnumerable<Photo> GetPhotos(DateTime filter)
        {
            // Log
            TravelJournalSimulation.Log(LogType.HighlightInfo, "Querying photos...");
            // Get photos
            List<Photo> photos = simulator.GetCreatedPhotos();
            if (filter != DateTime.MinValue)
                return photos.Where((photo) => { return photo.Position.GpsPoint.Timestamp > filter; });
            else
                return photos;
        }
        public GpsPosition GetGpsPosition(GpsPoint coordinate)
        {
            // Log 
            TravelJournalSimulation.Log(LogType.HighlightInfo, "Reverse geocode querying ...");
            // Reverse geocode
            return simulator.GetGpsPosition(coordinate);
        }

        #endregion
    


}


}
