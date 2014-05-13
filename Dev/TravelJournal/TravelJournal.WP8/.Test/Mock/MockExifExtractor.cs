using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.BusinessLogic;

namespace TravelJournal.WP8.Test
{
    public class MockExifExtractor:IExifExtractor
    {
        public PCL.DataService.GpsPoint ExtractGeoCoordinate(PCL.DataService.Photo p, System.IO.Stream photoStream)
        {
            // Mock photo exposes gps point directly.
            return p.Position.GpsPoint;
        }
    }
}
