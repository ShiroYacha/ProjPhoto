using GenericUndoRedo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournal.WinForm.Simulator.Forms
{
    [DataContract]
    [KnownType(typeof(TravelItineraryData))]
    public class TravelItineraryData:IConfigData
    {
        public event Action<IConfigData> OnDataChanged;
        public event Action<IConfigData> OnDataChanging;

        public string ConfigName
        {
            get {return "Travel itinerary data"; }
        }

        public string Extension
        {
            get { return ".tid"; }
        }

        private long timeIntervalPerAnchor;
        [DataMember()]
        public long TimeIntervalPerAnchor 
        {
            get { return timeIntervalPerAnchor; }
            set 
            {
                if (timeIntervalPerAnchor != value)
                {
                    if (OnDataChanging != null) OnDataChanging(this);
                        timeIntervalPerAnchor = value;
                    if(OnDataChanged!=null) OnDataChanged(this);
                }
            }
        }

        private float cameraProbPerSpot;
        [DataMember()]
        public float CameraProbPerSpot
        {
            get { return cameraProbPerSpot; }
            set
            {
                if (cameraProbPerSpot != value)
                {
                    if (OnDataChanging != null) OnDataChanging(this);
                    cameraProbPerSpot = value;
                    if (OnDataChanged != null) OnDataChanged(this);
                }
            }
        }
    }

}
