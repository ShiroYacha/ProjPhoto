using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TravelJournal.WinForm.Simulator.Controls;

namespace TravelJournal.WinForm.Simulator
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    public class ConnectionService : IConnectionService
    {
        private TravelSimulator simulator;
        private ConnectionTestData testData;

        public ConnectionService(TravelSimulator simulator)
        {
            this.simulator = simulator;
        }

        private ConnectionTestData CreateTestData(int size)
        {
            ConnectionTestData testData = new ConnectionTestData();
            testData.Data = new List<int>();
            for (int i = 0; i < size; i++)
                testData.Data.Add(i);
            return testData;
        }

        public bool Connect(string deviceName)
        {
            if (simulator.IsConnected == true)
                simulator.IsConnected = false;
            else
                simulator.IsConnected = true;
            // Log 
            TravelJournalSimulation.Log(LogType.Info, string.Format("Device {0} is {1}...",deviceName,simulator.IsConnected?"connected":"disconnected"));
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

        public void ReportLatency(decimal latency)
        {
            TravelJournalSimulation.UpdateConnectionViewer(latency);
            TravelJournalSimulation.Log(LogType.Info, string.Format("Test package of size {0} elements is downloaded.",testData.Data.Count));
        }
        #endregion

        public void Log(LogType type, string log, [CallerMemberName] string callerName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLine = -1)
        {
            TravelJournalSimulation.Log(type, log, callerName, callerFilePath, callerLine);
        }
    }


}
