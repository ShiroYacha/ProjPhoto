using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Services;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.DataService;
using BingMapsRESTService.Common.JSON;
using Windows.Devices.Geolocation;
using System.Windows;

namespace TravelJournal.WP8.DataService
{
    public class WpWebService:IWebService
    {
        public async Task<GpsPosition> GetUserPosition()
        {
            Geolocator locator = new Geolocator(); locator.DesiredAccuracy = PositionAccuracy.High;
            Geoposition geoposition = await locator.GetGeopositionAsync();
            return await GetGeoposition(ConvertGeopositionToGpsPoint(geoposition));
        }
        public async Task<GpsPosition> GetGeoposition(GpsPoint coordinate)
        {
            //ReverseGeocodeQuery query = new ReverseGeocodeQuery();
            //query.GeoCoordinate = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
            var tcs = new TaskCompletionSource<GpsPosition>();
            //query.QueryCompleted += (s, e) => { tcs.SetResult(ConvertMapLocationsToGpsPosition(coordinate, coordinate.Timestamp, e.Result)); };
            //query.QueryAsync();
            //return await tcs.Task;
            Uri geocodeRequest = new Uri(string.Format("http://dev.virtualearth.net/REST/v1/Locations/{0},{1}?o=json&key={2}", coordinate.Latitude, coordinate.Longitude, "AgVYbJgEyzwB25zWBg56k39viigKMvVcGKX7M6gkVbsd-zugS37c3tugNHmXc_Gs"));

            GetResponse(geocodeRequest, (x) =>
            {
                tcs.SetResult(ConvertQueryResponseToGpsPosition(coordinate, x.ResourceSets[0].Resources[0] as Location));
            });
            return await tcs.Task;
        }

        private static void GetResponse(Uri uri, Action<Response> callback)
        {
            WebClient wc = new WebClient();
            wc.OpenReadCompleted += (o, a) =>
            {
                if (callback != null)
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
                    callback(ser.ReadObject(a.Result) as Response);
                }
            };
            wc.OpenReadAsync(uri);
        }
        private static GpsPoint ConvertGeopositionToGpsPoint(Geoposition position)
        {
            return new GpsPoint()
            {
                Latitude = position.Coordinate.Latitude, 
                Longitude = position.Coordinate.Longitude,
                Timestamp = DateTime.Now
            }; 
        }
        private static GpsPosition ConvertQueryResponseToGpsPosition(GpsPoint coordinate, Location location)
        {
            return new GpsPosition()
            {
                GpsPoint = coordinate,
                City = location.Address.AdminDistrict,
                Country = location.Address.CountryRegion
            }; 
        }
    }
}
