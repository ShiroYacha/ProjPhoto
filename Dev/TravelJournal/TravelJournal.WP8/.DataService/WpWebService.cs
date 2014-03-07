using Microsoft.Phone.Maps.Services;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.DataService;
using Windows.Devices.Geolocation;

namespace TravelJournal.WP8.DataService
{
    public class WpWebService:IWebService
    {
        public async Task<GpsPosition> GetUserPosition()
        {
            Geolocator locator = new Geolocator(); locator.DesiredAccuracy = PositionAccuracy.High;
            Geoposition position = await locator.GetGeopositionAsync();
            return ConvertGeopositionToGpsPosition(position);
        }

        public async Task<GpsPosition> GetGeoposition(GpsPoint coordinate,DateTime timestamp)
        {
            ReverseGeocodeQuery query = new ReverseGeocodeQuery();
            query.GeoCoordinate = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
            var tcs = new TaskCompletionSource<GpsPosition>();
            query.QueryCompleted += (s, e) => { tcs.SetResult(ConvertMapLocationsToGpsPosition(coordinate, timestamp, e.Result)); };
            query.QueryAsync();
            return await tcs.Task;
        }

        private static GpsPosition ConvertGeopositionToGpsPosition(Geoposition position)
        {
            return new GpsPosition()
            {
                GpsPoint = new GpsPoint(position.Coordinate.Latitude, position.Coordinate.Longitude, position.CivicAddress.Timestamp.DateTime),
                City = position.CivicAddress.City,
                Country = position.CivicAddress.Country
            }; 
        }

        private static GpsPosition ConvertMapLocationsToGpsPosition(GpsPoint coordinate,DateTime timestamp, IList<MapLocation> locations)
        {
            MapLocation location = locations[0];
            return new GpsPosition()
            {
                GpsPoint = new GpsPoint(location.GeoCoordinate.Latitude, location.GeoCoordinate.Longitude, timestamp),
                City = location.Information.Address.City,
                Country = location.Information.Address.Country
            }; 
        }
    }
}
