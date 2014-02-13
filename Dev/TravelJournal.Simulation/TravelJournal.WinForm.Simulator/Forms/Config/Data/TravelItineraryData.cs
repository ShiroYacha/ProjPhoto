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

        private List<GpsPoint> anchors=new List<GpsPoint>();
        [DataMember()]
        public List<GpsPoint> Anchors
        {
            get { return anchors; }
            set
            {
                if (anchors != value)
                {
                    if (OnDataChanging != null) OnDataChanging(this);
                    anchors = value;
                    if (OnDataChanged != null) OnDataChanged(this);
                }
            }
        }
        public void AddAnchor(GpsPoint anchor)
        {
            if (OnDataChanging != null) OnDataChanging(this);
            anchors.Add(anchor);
            if (OnDataChanged != null) OnDataChanged(this);
        }

        private List<GpsPoint> cameraSpots = new List<GpsPoint>();
        [DataMember()]
        public List<GpsPoint> CameraSpots
        {
            get { return cameraSpots; }
            set
            {
                if (cameraSpots != value)
                {
                    if (OnDataChanging != null) OnDataChanging(this);
                    cameraSpots = value;
                    if (OnDataChanged != null) OnDataChanged(this);
                }
            }
        }
        public void AddCameraSpot(GpsPoint cameraSpot)
        {
            if (OnDataChanging != null) OnDataChanging(this);
            cameraSpots.Add(cameraSpot);
            if (OnDataChanged != null) OnDataChanged(this);
        }

        public void ClearAnchorsAndCameraSpots()
        {
            if (anchors.Count > 0 || cameraSpots.Count > 0)
            {
                if (OnDataChanging != null) OnDataChanging(this);
                anchors.Clear();
                cameraSpots.Clear();
                if (OnDataChanged != null) OnDataChanged(this);
            }
        }
    }

    [DataContract]
    [KnownType(typeof(GpsPoint))]
    public class GpsPoint
    {
        [DataMember()]
        public double Lat { get; set; }
        [DataMember()]
        public double Lng { get; set; }
    }

}
