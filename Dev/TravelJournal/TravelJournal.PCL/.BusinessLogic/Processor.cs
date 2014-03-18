using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.DataService;
using System.Threading;

namespace TravelJournal.PCL.BusinessLogic
{
    public class Processor
    {
        private DateTime nowTime;
        private Album album;
        private State state;
        private static Transition transition;
        private List<GpsPoint> tourRoutePoints ;
        private List<string> touristCity;
        private bool albumCompleted;
        private GpsPosition userPosition;

        public IWebService WebService { get { return SimpleIoc.Default.GetInstance<IWebService>(); } }

        public DataManagerBase DataManager { get { return SimpleIoc.Default.GetInstance<DataManagerBase>(); } }

        public IPhotoOrganizer PhotoOrganizer { get { return SimpleIoc.Default.GetInstance<IPhotoOrganizer>(); } }

        public IPhotoManager PhotoManager { get { return SimpleIoc.Default.GetInstance<IPhotoManager>(); } }

        public IExifExtractor ExifExtractor { get { return SimpleIoc.Default.GetInstance<IExifExtractor>(); } }

        public DateTime NowTime
        {
            get { return nowTime; }
            set { nowTime = value; }
        }
        public Album Album
        {
            get { return album; }
            set { album = value; }
        }
        public Processor() { }
       
        public State State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public List<GpsPoint> TourRoutePoints
        {
            get {return tourRoutePoints;}
            set { tourRoutePoints = value; }
        }
        public List<string> TouristCity
        {
            get { return touristCity; }
            set { touristCity = value; }
        }

        public bool AlbumCompleted
        {
            get { return albumCompleted; }
            set { albumCompleted = value; }
        }

        public GpsPosition UserPosition
        {
            get { return userPosition; }
            set{userPosition = value;}
        }
        public void CheckState()
        {
            Transition t = GetTransitionInstance();
            t.Transform(this);
        }
        public static Transition GetTransitionInstance()
        {
            if (transition == null)
            {
                transition = new Transition();
            }
            return transition;
        }

        public async void PhotoHandler(Photo aPhoto)
        {
            GpsPoint p = ExifExtractor.ExtractGeoCoordinate(aPhoto);
            aPhoto.Position = await WebService.GetGeoposition(p);
            PhotoOrganizer.OrganizePhoto(aPhoto, album);
            album.TimeTag = DateTime.Now;          
        }

        public static void Execute()
        {
            Processor processor = new Processor();
            processor.DataManager.Load();
            processor.CheckState();
            processor.State.Execute(processor);
            processor.DataManager.Save();
        }
    }
}
