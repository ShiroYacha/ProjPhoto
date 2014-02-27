using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournal.WinForm.Simulator
{
    [DataContract]
    [KnownType(typeof(SimulationModelPoint))]
    public class SimulationModelPoint
    {
        [DataMember()]
        public PointLatLng Gps { get; set; }
        [DataMember()]
        public int PhotoGenNumber { get; set; }
        [DataMember()]
        public long CustomTimeInterval { get; set; }
    }
}
