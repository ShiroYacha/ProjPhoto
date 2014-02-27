using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL;
using TravelJournal.PCL.DataService;
using TravelJournal.WinForm.Simulator.Controls;

namespace TravelJournal.WinForm.Simulator
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SimulationServices : ISimulationServices
    {
        private const decimal THRESHOLD_LATENCY_WARNING = 2;
        private const decimal THRESHOLD_LATENCY_FAILURE = 5;

        private TravelSimulator simulator;
        private ConnectionTestData testData;

        public SimulationServices(TravelSimulator simulator)
        {
            this.simulator = simulator;
        }

        #region Connection services

        public bool Connect(string deviceName)
        {
            if (simulator.IsConnected == false)
            {
                simulator.IsConnected = true;
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

        public void ReportLatency(decimal latency)
        {
            TravelJournalSimulation.UpdateConnectionViewer(latency);
            if (latency > THRESHOLD_LATENCY_FAILURE)
                TravelJournalSimulation.Log(LogType.Error, string.Format("Client query latency {0}s surpassed {1}s...", latency.ToString("#.##"), THRESHOLD_LATENCY_FAILURE.ToString("#.##")));
            else if (latency > THRESHOLD_LATENCY_WARNING)
                TravelJournalSimulation.Log(LogType.Warning, string.Format("Client query latency {0}s surpassed {1}s...",latency.ToString("#.##"),THRESHOLD_LATENCY_WARNING.ToString("#.##")));
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
            TravelJournalSimulation.Log(LogType.Info, "Querying current position...");
            // Get current gps
            return simulator.GetCurrentGps();
        }
        public IEnumerable<Photo> GetPhotos(DateTime filter)
        {
            // Log
            TravelJournalSimulation.Log(LogType.Info, "Querying photos...");
            // Get photos
            List<Photo> photos = simulator.GetCreatedPhotos();
            if (filter != DateTime.MinValue)
                return photos.Where((photo) => { return photo.Point.TimeStamp > filter; });
            else
                return photos;
        }

        #endregion
    }


}
