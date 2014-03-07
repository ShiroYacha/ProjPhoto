using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.DataService;
using System.Threading;

namespace TravelJournal.PCL.BusinessLogic
{
    class Processor
    {
       
        private DateTime nowTime;
        private Album album;
        private State state;
        private bool isInTravel;
        private List<GpsPoint> tourRoutePoints = new List<GpsPoint>();
        private List<string> touristCity = new List<string>();
        



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
        public Processor(State state)
        {
            this.state = state;     
        }
        public State GetState()
        {
            return this.state;
        }
        public void SetState(State state)
        {
            this.state = state;
        }
        public bool GetIsInTravel()
        {
            return this.isInTravel;
        }
        public void SetIsInTravel(bool isInTravel)
        {
            this.isInTravel = isInTravel;
        }
        public void Execute()
        {
            this.state.Execute(this);
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


        public async void PhotoHandler(Photo aPhoto)
        {
            GpsPoint p = ExifExtractor.ExtractGeoCoordinate(aPhoto);
            aPhoto.Position = await WebService.GetGeoposition(p);
            PhotoOrganizer.OrganizePhoto(aPhoto, album);
            album.TimeTag = DateTime.Now;          
        }

        public void MainExecute()
        {
            DataManager.Load();
            Processor processor = new Processor(new OriginalState());
            processor.Execute();
            DataManager.Save();
        }
    }
}
