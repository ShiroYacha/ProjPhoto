using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.ServiceReference;

namespace TravelJournal.PCL.Test
{
    public abstract class TravelInfoTesterAgentBase : ServerAgentBase
    {

        public void UpdateCurrentGps()
        {
            OperationStart();
            serviceClient.GetCurrentGpsCompleted += serviceClient_GetCurrentGpsCompleted;
            serviceClient.GetCurrentGpsAsync();
        }

        void serviceClient_GetCurrentGpsCompleted(object sender, ServiceReference.GetCurrentGpsCompletedEventArgs e)
        {
            serviceClient.GetCurrentGpsCompleted -= serviceClient_GetCurrentGpsCompleted;
            if (e.Result != null)
                SendCurrentGps(e.Result);
            else
                OperationEndDirectly();
        }

        public void SendCurrentGps(GpsPoint point)
        {
            string pointString=string.Format("({0}|{1})",point.Latitude.ToString("#.###"),point.Longitude.ToString("#.###"));
            serviceClient.UpdateInfoInspectorCompleted += serviceClient_UpdateInfoInspectorCompleted;
            serviceClient.UpdateInfoInspectorAsync(new Dictionary<string, object>() { { "Current gps", pointString } });
        }

        void serviceClient_UpdateInfoInspectorCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            serviceClient.UpdateInfoInspectorCompleted -= serviceClient_UpdateInfoInspectorCompleted;
            OperationEnd();
        }



    }
}
