using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL;
using TravelJournal.WinForm.Simulator.Controls;

namespace TravelJournal.WinForm.Simulator
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SimulationServices : ISimulationServices
    {
        private TravelSimulator simulator;
        private ConnectionTestData testData;

        public SimulationServices(TravelSimulator simulator)
        {
            this.simulator = simulator;
        }

        public bool Connect(string deviceName)
        {
            if (simulator.IsConnected == true)
                simulator.IsConnected = false;
            else
                simulator.IsConnected = true;
            // Log 
            TravelJournalSimulation.Log(LogType.Info, string.Format("Device {0} is {1}...", deviceName, simulator.IsConnected ? "connected" : "disconnected"));
            return simulator.IsConnected;
        }

        #region Connection test members

        public void PrepareTestData(int size)
        {
            testData = CreateTestData(size);
        }
        public ConnectionTestData GetTestData()
        {
            // Pure download operation
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
            TravelJournalSimulation.Log(LogType.Info, "Client query ended...");
        }
        public void Log(LogType type, string log, [CallerMemberName] string callerName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLine = -1)
        {
            TravelJournalSimulation.Log(type, log, callerName, callerFilePath, callerLine);
        }
        public void UpdateInfoInspector(Dictionary<string, object> infos)
        {
            TravelJournalSimulation.UpdateInfoInspector(infos);
        }
        #endregion

        public GpsPoint GetCurrentGps()
        {
            // Log 
            TravelJournalSimulation.Log(LogType.Info, "Querying current position...");
            return simulator.GetCurrentGps();
        }


    }


}
