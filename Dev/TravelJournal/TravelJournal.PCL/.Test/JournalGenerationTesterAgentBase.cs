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
            Processor.ExecuteForTest(ReportExecutionStatus);
        }

        private void ReportExecutionStatus(Data data)
        {
            // Update state machine
            // Send album
            SendAlbums(new List<TravelJournal.PCL.ServiceReference.Album>() { WrapAlbum(data.AlbumsCollection[0]) });
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

        private ServiceReference.Album WrapAlbum(Album album)
        {
            return new TravelJournal.PCL.ServiceReference.Album()
            {
                AlbumName = album.AlbumName,
                TimeTag = album.TimeTag,
                PhotoList = new List<ServiceReference.Photo>(album.PhotoList.Select<Photo,ServiceReference.Photo>
                    ((p) => { return WrapPhoto(p); }))
            };
        }
        private ServiceReference.Photo WrapPhoto(Photo photo)
        {
            return new ServiceReference.Photo()
            {
                PhotoName=photo.PhotoName,
                Position = WrapGpsPosition(photo.Position),

            };
        }
        private ServiceReference.GpsPoint WrapGpsPoint(GpsPoint pointToWrap)
        {
            return new ServiceReference.GpsPoint()
            {
                Latitude = pointToWrap.Latitude,
                Longitude = pointToWrap.Longitude,
                Timestamp = pointToWrap.Timestamp
            };
        }
        private ServiceReference.GpsPosition WrapGpsPosition(GpsPosition positionToWrap)
        {
            return new ServiceReference.GpsPosition()
            {
                City = positionToWrap.City,
                Country = positionToWrap.Country,
                GpsPoint = WrapGpsPoint(positionToWrap.GpsPoint)
            };
        }
    }
}
