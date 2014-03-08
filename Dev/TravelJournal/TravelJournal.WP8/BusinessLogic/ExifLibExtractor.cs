using ExifLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.BusinessLogic;
using TravelJournal.PCL.DataService;

namespace TravelJournal.WP8.BusinessLogic
{
    public class ExifLibExtractor : IExifExtractor
    {
        public GpsPoint ExtractGeoCoordinate(Photo p)
        {
            using (ExifReader reader = new ExifReader(p.PhotoName))
            {
                // Extract geo coordinates
                double[] latitudeDMS;
                reader.GetTagValue(ExifTags.GPSLatitude, out latitudeDMS);
                double[] longitudeDMS;
                reader.GetTagValue(ExifTags.GPSLongitude, out longitudeDMS);
                string latitudeRef;
                reader.GetTagValue(ExifTags.GPSLatitudeRef, out latitudeRef);
                string longitudeRef;
                reader.GetTagValue(ExifTags.GPSLongitudeRef, out longitudeRef);
                // Reconstuct latitude and longitude (lat/lng are stored as D°M'S" arrays)
                double latitudeDecimalDegrees = (latitudeRef == "N" ? 1 : -1) *
                   (latitudeDMS[0] + latitudeDMS[1] / 60 + latitudeDMS[2] / 3600);
                double longitudeDecimalDegrees = (longitudeRef == "E" ? 1 : -1) *
                                (longitudeDMS[0] + longitudeDMS[1] / 60 + longitudeDMS[2] / 3600);
                return new GpsPoint(longitudeDecimalDegrees, latitudeDecimalDegrees, p.Position.GpsPoint.Timestamp);
            }
        }
    }
}
