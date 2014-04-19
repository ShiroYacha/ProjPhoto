using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TravelJournal.PCL.DataService
{
    [DataContract]
    public class Photo
    {
        [DataMember]
        public string PhotoName{get;set;}
        [DataMember]
        public GpsPosition Position { get; set; }
        [DataMember]
        public System.IO.Stream Stream { get; set; }
    }
}
