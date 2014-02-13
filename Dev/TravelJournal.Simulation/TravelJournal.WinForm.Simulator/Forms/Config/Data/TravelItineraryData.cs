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

        private double cameraRadius=1;
        [DataMember()]
        public double CameraRadius
        {
            get { return cameraRadius; }
            set
            {
                if (cameraRadius != value)
                {
                    if (OnDataChanging != null) OnDataChanging(this);
                    cameraRadius = value;
                    if (OnDataChanged != null) OnDataChanged(this);
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
                if (OnDataChanging != null) OnDataChanging(this);
                homePlacemark = value;
                if (OnDataChanged != null) OnDataChanged(this);
            }
        }

        private List<SimulationModelPoint> anchors = new List<SimulationModelPoint>();
        [DataMember()]
        public List<SimulationModelPoint> Anchors
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
        public void AddAnchor(SimulationModelPoint anchor)
        {
            if (OnDataChanging != null) OnDataChanging(this);
            anchors.Add(anchor);
            if (OnDataChanged != null) OnDataChanged(this);
        }
        public void ClearAnchors()
        {
            if (anchors.Count > 0)
            {
                if (OnDataChanging != null) OnDataChanging(this);
                anchors.Clear();
                if (OnDataChanged != null) OnDataChanged(this);
            }
        }
        public void SetAnchorPhotoGenNumber(int index, int photoGenNumber)
        {
            if (anchors.Count > index)
            {
                if (OnDataChanging != null) OnDataChanging(this);
                anchors[index].PhotoGenNumber = photoGenNumber;
                if (OnDataChanged != null) OnDataChanged(this);
            }
        }
    }



    
}
