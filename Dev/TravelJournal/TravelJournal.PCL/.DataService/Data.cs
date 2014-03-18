using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.BusinessLogic;
using System.Runtime.Serialization;

namespace TravelJournal.PCL.DataService
{
    [DataContract]
    public class Data
    {
        private List<Album> albumsCollection;
        private UserInfo userInfo;
        private State state;
        private List<GpsPoint> tourRoutePoints = new List<GpsPoint>();
        private List<string> touristCity = new List<string>();
        private bool albumCompleted;
        
        [DataMember]
        public List<GpsPoint> TourRoutePoints
        {
            get { return tourRoutePoints; }
            set { tourRoutePoints = value; }
        }
        [DataMember]
        public List<string> TouristCity
        {
            get { return touristCity; }
            set { touristCity = value; }
        }

        [DataMember]
        public bool AlbumCompleted
        {
            get { return albumCompleted; }
            set { albumCompleted = value; }
        }

        [DataMember]
        public List<Album> AlbumsCollection
        {
            get { return albumsCollection; }
            set { albumsCollection = value; }
        }

        [DataMember]
        public UserInfo UserInfo
        {
            get { return this.userInfo; }
            set { userInfo = value; }
        }

        [DataMember]
        public State State
        {
            get { return this.state; }
            set { state = value; }
        }
    }
}
