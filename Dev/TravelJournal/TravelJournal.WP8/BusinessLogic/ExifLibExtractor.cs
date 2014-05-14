using ExifLib;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TravelJournal.PCL.BusinessLogic;
using TravelJournal.PCL.DataService;
using TravelJournal.WP8.DataService;

namespace TravelJournal.WP8.BusinessLogic
{
    public class ExifLibExtractor : IExifExtractor
    {
        public GpsPoint ExtractGeoCoordinate(Photo photo)
        {
            Stream stream=new WpPhotoManager().GetPhotoStream(photo.Name);
            using (ExifReader reader = new ExifReader(stream))
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
                DateTime timestamp;
                reader.GetTagValue(ExifTags.DateTimeOriginal, out timestamp);
                // Reconstuct latitude and longitude (lat/lng are stored as D°M'S" arrays)
                if (latitudeDMS != null)
                {
                    double latitudeDecimalDegrees = (latitudeRef == "N" ? 1 : -1) *
                       (latitudeDMS[0] + latitudeDMS[1] / 60 + latitudeDMS[2] / (3600 * 1000));
                    double longitudeDecimalDegrees = (longitudeRef == "E" ? 1 : -1) *
                                    (longitudeDMS[0] + longitudeDMS[1] / 60 + longitudeDMS[2] / (3600 * 1000));
                    return new GpsPoint(longitudeDecimalDegrees, latitudeDecimalDegrees, timestamp);
                }
                else
                    return new GpsPoint(0, 0, timestamp);
            }
        }
    }
}
