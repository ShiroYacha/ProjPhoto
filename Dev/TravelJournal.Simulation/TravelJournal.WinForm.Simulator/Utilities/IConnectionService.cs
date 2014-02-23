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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IConnectionService" in both code and config file together.
    [ServiceContract]
    public interface IConnectionService
    {
        [OperationContract]
        bool Connect(string deviceName);

        [OperationContract]
        void PrepareTestData(int size);

        [OperationContract]
        ConnectionTestData GetTestData();

        [OperationContract]
        void ReportLatency(decimal latency);

        [OperationContract]
        void Log(LogType type, string log, [CallerMemberName] string callerName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLine = -1);
    }
}
