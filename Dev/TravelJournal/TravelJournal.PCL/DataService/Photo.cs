using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.DataService
{
    public class Photo
    {
        public string Name{get;set;}
        public GpsPoint Point{get;set;}
        public GpsPosition Position { get; set; }

    }
}
