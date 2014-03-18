using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.BusinessLogic;
using TravelJournal.PCL.DataService;

namespace TravelJournal.PCL.Test
{
    public abstract class JournalGenerationTesterAgentBase:TravelInfoTesterAgentBase
    {
        public override void OnInvoke()
        {
            // Start operation
            OperationStart();
            Processor.Execute();
            ReportExecutionStatus();
        }

        private void ReportExecutionStatus()
        {
            
        }

        private Action<GpsPosition> reverseGeocodingQueryCallback = null;
        private GpsPoint gpsPoint; 
        public void ReverseGeocodingQuery(GpsPoint gpsPoint,Action<GpsPosition> callback = null)
        {
            this.reverseGeocodingQueryCallback = callback;
            this.gpsPoint = gpsPoint;
            serviceClient.GetGpsPositionCompleted += serviceClient_GetGpsPositionCompleted;
            serviceClient.GetGpsPositionAsync(new ServiceReference.GpsPoint() { Latitude = gpsPoint.Latitude, Longitude = gpsPoint.Longitude, Timestamp = gpsPoint.Timestamp });
        }
        void serviceClient_GetGpsPositionCompleted(object sender, ServiceReference.GetGpsPositionCompletedEventArgs e)
        {
            serviceClient.GetGpsPositionCompleted -= serviceClient_GetGpsPositionCompleted;
            if (reverseGeocodingQueryCallback != null)
                reverseGeocodingQueryCallback(new GpsPosition(){
                    GpsPoint = this.gpsPoint,
                    City=e.Result.City,
                    Country=e.Result.Country
                });
        }
    }
}
