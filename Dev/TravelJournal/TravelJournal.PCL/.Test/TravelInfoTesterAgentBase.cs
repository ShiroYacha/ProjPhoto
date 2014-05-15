using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.ServiceReference;

namespace TravelJournal.PCL.Test
{
    public abstract class  TravelInfoTesterAgentBase : ServerAgentBase
    {
        private int finishedTaskCount;
        private const int TASK_COUNT = 2;

        public override void OnInvoke()
        {
            // Start operation
            finishedTaskCount = 0;
            OperationStart();
            UpdateCurrentGps();
            QueryPhotos(DateTime.MinValue);
        }
        protected override void OperationEndDirectly()
        {
            base.OperationEndDirectly();
            finishedTaskCount = 0;
        }

        private Action<GpsPoint> updateCurrentGpsCallback;
        public void UpdateCurrentGps(Action<GpsPoint> callback=null)
        {
            serviceClient.GetCurrentGpsCompleted += serviceClient_GetCurrentGpsCompleted;
            this.updateCurrentGpsCallback = callback;
            serviceClient.GetCurrentGpsAsync();
        }
        private void serviceClient_GetCurrentGpsCompleted(object sender, ServiceReference.GetCurrentGpsCompletedEventArgs e)
        {
            serviceClient.GetCurrentGpsCompleted -= serviceClient_GetCurrentGpsCompleted;
            if (e.Result != null)
            {
                SendCurrentGps(e.Result);
                if (updateCurrentGpsCallback != null)
                    updateCurrentGpsCallback(e.Result);
            }
            else
                OperationEndDirectly();
        }

        private void SendCurrentGps(GpsPoint point)
        {
            string pointString=string.Format("({0}|{1})",point.Latitude.ToString("#.###"),point.Longitude.ToString("#.###"));
            serviceClient.UpdateInfoInspectorCompleted += serviceClient_UpdateInfoInspectorCompleted;
            serviceClient.UpdateInfoInspectorAsync(new Dictionary<string, object>() { { "Current gps", pointString } });
        }
        private void serviceClient_UpdateInfoInspectorCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            serviceClient.UpdateInfoInspectorCompleted -= serviceClient_UpdateInfoInspectorCompleted;
            if (++finishedTaskCount == TASK_COUNT)
                OperationEnd();
        }

        public void QueryPhotos(DateTime filter, Action<List<Photo>> queryCompletedHandler = null)
        {
            if (queryCompletedHandler != null)
                serviceClient.GetPhotosCompleted += (s, e) =>
                { 
                    serviceClient.GetPhotosCompleted -= serviceClient_GetPhotosCompleted; queryCompletedHandler(e.Result);
                };
            serviceClient.GetPhotosCompleted += serviceClient_GetPhotosCompleted;
            serviceClient.GetPhotosAsync(filter);
        }
        private void serviceClient_GetPhotosCompleted(object sender, GetPhotosCompletedEventArgs e)
        {
            serviceClient.GetPhotosCompleted -= serviceClient_GetPhotosCompleted;
            SendAlbums(new List<Album>() { new Album(){Name="Default album",PhotoList=e.Result}});
        }
        public void SendAlbums(List<Album> albums)
        {
            serviceClient.UpdatePhotoTreeViewCompleted += serviceClient_UpdatePhotoTreeViewCompleted;
            serviceClient.UpdatePhotoTreeViewAsync(albums);
        }
        void serviceClient_UpdatePhotoTreeViewCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            serviceClient.UpdatePhotoTreeViewCompleted -= serviceClient_UpdatePhotoTreeViewCompleted;
            if (++finishedTaskCount == TASK_COUNT)
                OperationEnd();
        }
    }
}
