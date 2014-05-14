using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.BusinessLogic;
using TravelJournal.PCL.DataService;

namespace TravelJournal.WP8.Test
{
    public class MockExifExtractor:IExifExtractor
    {
        public PCL.DataService.GpsPoint ExtractGeoCoordinate(Photo photo)
        {
            // Mock photo exposes gps point directly.
            return photo.Position.GpsPoint;
        }
    }
}
