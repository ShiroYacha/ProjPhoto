using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournal.WinForm.Simulator
{
    public class UserPositionService : IUserPositionService
    {
        private GpsPoint currentGps;

        public async void UpdateCurrentGps(GpsPoint currentGps)
        {
            await Task.Factory.StartNew(() =>
            {
                this.currentGps = currentGps;
            });
        }

        public GpsPoint GetCurrentGps()
        {
            return currentGps;
        }
    }
}
