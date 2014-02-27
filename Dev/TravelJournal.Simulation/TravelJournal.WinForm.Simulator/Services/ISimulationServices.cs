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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IConnectionService" in both code and config file together.
    [ServiceContract]
    public interface ISimulationServices
    {
        #region Connection services
       
        [OperationContract]
        bool Connect(string deviceName);
      
        [OperationContract]
        bool Disconnect(string deviceName); 
      
        #endregion

        #region Connectivity test services
       
        [OperationContract]
        void PrepareTestData(int size);
     
        [OperationContract]
        ConnectionTestData GetTestData(); 
     
        #endregion

        #region Diagnostics services

        [OperationContract]
        void ReportLatency(decimal latency);

        [OperationContract]
        void Log(LogType type, string log, [CallerMemberName] string callerName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLine = -1);
       
        [OperationContract]
        void UpdateInfoInspector(Dictionary<string, object> infos);
     
        [OperationContract]
        void UpdatePhotoTreeView(List<Album> albums);
    
        #endregion

        #region Core services
     
        [OperationContract]
        GpsPoint GetCurrentGps();
     
        [OperationContract]
        IEnumerable<Photo> GetPhotos(DateTime filter);
      
        #endregion

  }
}
