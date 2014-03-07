using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.DataService
{
    public class GpsPosition
    {
        public string Country { get; set; }
        public string City { get; set; }
        
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
