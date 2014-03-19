using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.DataService;

namespace TravelJournal.WP8.Test
{
    public class MockWebService:IWebService
    {
        JournalGenerationTesterAgent agent = new JournalGenerationTesterAgent();
        public async Task<GpsPosition> GetUserPosition()
        {
            var tcs = new TaskCompletionSource<GpsPosition>();
            agent.UpdateCurrentGps(async (gps) => 
            {
                tcs.SetResult(await GetGeoposition(WrapGpsPoint(gps))); 
            });
            return await tcs.Task;
        }

        public async Task<GpsPosition> GetGeoposition(GpsPoint coordinate)
        {
            var tcs = new TaskCompletionSource<GpsPosition>();
            agent.ReverseGeocodingQuery(coordinate, (gpsPosition) =>
                {
                    tcs.SetResult(gpsPosition);
                });
            return await tcs.Task;
        }
        
        private GpsPoint WrapGpsPoint(TravelJournal.PCL.ServiceReference.GpsPoint pointToWrap)
        {
            return new GpsPoint() 
            { 
                Latitude = pointToWrap.Latitude, Longitude = pointToWrap.Longitude, Timestamp = pointToWrap.Timestamp 
            };
        }

        private GpsPosition WrapGpsPosition(TravelJournal.PCL.ServiceReference.GpsPosition positionToWrap)
        {
            return new GpsPosition()
            {
                City=positionToWrap.City,
                Country=positionToWrap.Country,
                GpsPoint = WrapGpsPoint(positionToWrap.GpsPoint)
            };
        }
    }
}
