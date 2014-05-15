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
            Processor.ExecuteForTest(ReportExecutionStatus, SetupProcessor);
        }

        protected abstract Action<string> SetupProcessor(Processor processor);

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

        #region Wrappers 
        protected ServiceReference.Album WrapAlbum(Album album)
        {
            return new TravelJournal.PCL.ServiceReference.Album()
            {
                Name = album.Name,
                TimeTag = album.TimeTag,
                PhotoList = new List<ServiceReference.Photo>(album.PhotoList.Select<Photo, ServiceReference.Photo>
                    ((p) => { return WrapPhoto(p); }))
            };
        }
        protected ServiceReference.Photo WrapPhoto(Photo photo)
        {
            return new ServiceReference.Photo()
            {
                Name = photo.Name,
                Position = WrapGpsPosition(photo.Position),

            };
        }
        protected Photo WrapPhoto(ServiceReference.Photo photo)
        {
            return new Photo()
            {
                Name = photo.Name,
                Position = WrapGpsPosition(photo.Position),

            };
        }
        protected List<Photo> WrapPhotoList(List<ServiceReference.Photo> photos)
        {
            return new List<Photo>(photos.Select<ServiceReference.Photo, Photo>
                    ((p) => { return WrapPhoto(p); }));
        }
        protected ServiceReference.GpsPoint WrapGpsPoint(GpsPoint pointToWrap)
        {
            return new ServiceReference.GpsPoint()
            {
                Latitude = pointToWrap.Latitude,
                Longitude = pointToWrap.Longitude,
                Timestamp = pointToWrap.Timestamp
            };
        }
        protected GpsPoint WrapGpsPoint(ServiceReference.GpsPoint pointToWrap)
        {
            return new GpsPoint()
            {
                Latitude = pointToWrap.Latitude,
                Longitude = pointToWrap.Longitude,
                Timestamp = pointToWrap.Timestamp
            };
        }
        protected ServiceReference.GpsPosition WrapGpsPosition(GpsPosition positionToWrap)
        {
            return new ServiceReference.GpsPosition()
            {
                City = positionToWrap.City,
                Country = positionToWrap.Country,
                GpsPoint = WrapGpsPoint(positionToWrap.GpsPoint)
            };
        }
        protected GpsPosition WrapGpsPosition(ServiceReference.GpsPosition positionToWrap)
        {
            return new GpsPosition()
            {
                City = positionToWrap.City,
                Country = positionToWrap.Country,
                GpsPoint = WrapGpsPoint(positionToWrap.GpsPoint)
            };
        } 
        #endregion
    }
}
