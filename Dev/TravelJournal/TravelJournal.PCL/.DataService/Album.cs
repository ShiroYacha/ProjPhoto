using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace TravelJournal.PCL.DataService
{
    [DataContract]
    public class Album
    {
        DateTime timeTag;
        private string albumName;
        private List<Photo> photoList=new List<Photo>();

        [DataMember]
        public string Name
        {
            get
            {
                return albumName;
            }
            set
            {
                albumName = value;
            }
        }

        [DataMember]
        public List<Photo> PhotoList
        {
            get
            {
                return photoList;
            }
            set
            {
                photoList = value;
            }
        }

        public Album() { }

        [DataMember]
        public DateTime TimeTag
        {
            get
            {
                return timeTag;
            }
            set
            {
                timeTag = value;
            }
        }

        public GpsPoint GetAlbumGpsCentroid(string locationCriteria="")
        {
            if (photoList.Count > 0)
            {
                GpsPoint centroid = new GpsPoint(0,0,default(DateTime));
                foreach (Photo photo in locationCriteria == "" ? 
                    photoList : photoList.TakeWhile<Photo>((photo) => { return photo.Position.City == locationCriteria || photo.Position.Country == locationCriteria; }))
                    centroid += photo.Position.GpsPoint;
                centroid.Latitude/=photoList.Count;
                centroid.Longitude/=photoList.Count;
                return centroid;
            }
            return null;
        }

        public Tuple<GpsPoint, GpsPoint> GetAlbumGpsBoundingRectangle(string locationCriteria = "")
        {
            if (photoList.Count > 1)
            {
                GpsPoint northWest = photoList.OrderByDescending((photo) => { return photo.Position.GpsPoint.Latitude - photo.Position.GpsPoint.Longitude; }).First().Position.GpsPoint;
                GpsPoint northEast = photoList.OrderByDescending((photo) => { return photo.Position.GpsPoint.Latitude + photo.Position.GpsPoint.Longitude; }).First().Position.GpsPoint;
                GpsPoint southEast = photoList.OrderByDescending((photo) => { return photo.Position.GpsPoint.Longitude - photo.Position.GpsPoint.Latitude; }).First().Position.GpsPoint;
                GpsPoint southWest = photoList.OrderByDescending((photo) => { return -photo.Position.GpsPoint.Longitude - photo.Position.GpsPoint.Latitude; }).First().Position.GpsPoint;
                GpsPoint northWestBound = new GpsPoint(Math.Min(northWest.Longitude, southWest.Longitude), Math.Max(northEast.Latitude, northWest.Latitude), default(DateTime));
                GpsPoint southEastBound = new GpsPoint(Math.Max(southEast.Longitude, northEast.Longitude), Math.Min(southEast.Latitude, southWest.Latitude), default(DateTime));
                return new Tuple<GpsPoint, GpsPoint>(northWestBound, southEastBound);
            }
            return null;
        }
    }

}
