using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournal.WinForm.Simulator
{
    [DataContract]
    public class GpsPoint
    {
        [DataMember]
        double Lat { get; set; }

        [DataMember]
        double Lng { get; set; }

        [DataMember]
        DateTime TimeStamp { get; set; }
    }
}
