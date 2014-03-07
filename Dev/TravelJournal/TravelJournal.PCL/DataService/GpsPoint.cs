using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TravelJournal.PCL.DataService
{
    [DataContract]
    public class GpsPoint
    {
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public double Longitude { get; set; }

        [DataMember]
        public DateTime Timestamp { get; set; }

        public GpsPoint() { }
        public GpsPoint(double longitude,double latitude, DateTime time){

            Longitude = longitude;
            Latitude = latitude;
            Timestamp = time;
        }
    }
}
