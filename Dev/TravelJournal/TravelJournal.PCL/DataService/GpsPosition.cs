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

        public GpsPosition() { }

        public GpsPosition(string country, string city) 
        {
            Country = country;
            City = city;
        }
    }
}
