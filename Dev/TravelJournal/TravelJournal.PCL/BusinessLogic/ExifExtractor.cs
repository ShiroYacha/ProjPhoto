using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.DataService;

namespace TravelJournal.PCL.BusinessLogic
{
    class ExifExtractor:IExifExtractor
    {

        public DataService.GpsPoint ExtractGeoCoordinate(Photo p)
        {
            return p.Point;
        }
    }
}
