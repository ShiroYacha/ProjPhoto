using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TravelJournal.PCL.DataService
{
    [DataContract]
    public class GpsPosition
    {
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public GpsPoint GpsPoint{get;set;}
        public GpsPosition() { }
        public GpsPosition(string country, string city,GpsPoint gpsPoint) 
        {
            Country = country;
            City = city;
            GpsPoint = gpsPoint;
        }
    }
}
