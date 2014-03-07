using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.DataService
{
    public class GpsPoint
    {
       public double Longitude { get; set; }

       public  double Latitude { get; set; }

       public  DateTime Timestamp { get; set; }

        public GpsPoint() { }
        public GpsPoint(double longitude,double latitude, DateTime time){

            Longitude = longitude;
            Latitude = latitude;
            Timestamp = time;
        }
    }
}
