using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournal.WinForm.Simulator.Forms
{
    public class TravelItineraryData:IConfigData
    {
        public string ConfigName
        {
            get {return "Travel itinerary data"; }
        }

        public string Extension
        {
            get { return ".tid"; }
        }
    }
}
