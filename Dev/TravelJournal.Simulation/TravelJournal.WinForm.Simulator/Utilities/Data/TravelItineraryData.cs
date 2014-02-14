using GenericUndoRedo;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournal.WinForm.Simulator
{
    [DataContract]
    [KnownType(typeof(TravelItineraryData))]
    public class TravelItineraryData : ConfigDataBase
    {
        private const long DEFAULT_TIME_INTERVAL_PER_ANCHOR = 5000;
        private const long DEFAULT_CAMERA_RADIUS = 1;

        public override string ConfigName
        {
            get { return "Travel itinerary data"; }
        }

        public override string Extension
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
                    OnDataChanging();
                    timeIntervalPerAnchor = value;
                    OnDataChanged();
                }
            }
        }

        private double cameraRadius;
        [DataMember()]
        public double CameraRadius
        {
            get { return cameraRadius; }
            set
            {
                if (cameraRadius != value)
                {
                    OnDataChanging();
                    cameraRadius = value;
                    OnDataChanged();
                }
            }
        }

        private Placemark homePlacemark;
        [DataMember()]
        public Placemark HomePlacemark
        {
            get { return homePlacemark; }
            set
            {
                OnDataChanging();
                homePlacemark = value;
                OnDataChanged();
            }
        }

        private List<SimulationModelPoint> anchors;
        [DataMember()]
        public List<SimulationModelPoint> Anchors
        {
            get { return anchors; }
            set
            {
                if (anchors != value)
                {
                    OnDataChanging();
                    anchors = value;
                    OnDataChanged();
                }
            }
        }
        public void AddAnchor(SimulationModelPoint anchor)
        {
            OnDataChanging();
            anchors.Add(anchor);
            OnDataChanged();
        }
        public void ClearAnchors()
        {
            if (anchors.Count > 0)
            {
                OnDataChanging();
                anchors.Clear();
                OnDataChanged();
            }
        }
        public void SetAnchorPhotoGenNumber(int index, int photoGenNumber)
        {
            if (anchors.Count > index)
            {
                OnDataChanging();
                anchors[index].PhotoGenNumber = photoGenNumber;
                OnDataChanged();
            }
        }

        public override Dictionary<string, string> Display()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("Default time interval ", timeIntervalPerAnchor.ToString() + "ms");
            data.Add("Camera gen radius", cameraRadius.ToString() + "km");
            return data;
        }
        public override void Initialize()
        {
            timeIntervalPerAnchor = DEFAULT_TIME_INTERVAL_PER_ANCHOR;
            cameraRadius = DEFAULT_CAMERA_RADIUS;
            anchors = new List<SimulationModelPoint>();
        }
        public bool IsComplete
        {
            get
            {
                return anchors.Count > 2;
            }
        }
        public bool IsCompiled
        {
            get
            {
                return anchors.TrueForAll((anchor) => { return anchor.PhotoGenNumber <= 1; });
            }
        }
    }
}
