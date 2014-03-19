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
        private static Transition transition;

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
            get { return this.album; }
            set {this.album=value;}
        }
        public Processor() { }
       
        public State State
        {
            get { return DataManager.Data.State; }
            set { DataManager.Data.State = value; }
        }

        public List<GpsPoint> TourRoutePoints
        {
            get { return DataManager.Data.TourRoutePoints; }
            set { DataManager.Data.TourRoutePoints = value; }
        }
        public List<string> TouristCity
        {
            get { return DataManager.Data.TouristCity; }
            set { DataManager.Data.TouristCity = value; }
        }

        public bool AlbumCompleted
        {
            get { return DataManager.Data.AlbumCompleted; }
            set { DataManager.Data.AlbumCompleted = value; }
        }

        public GpsPosition UserPosition
        {
            get { return DataManager.Data.UserInfo.UserPosition; }
            set { DataManager.Data.UserInfo.UserPosition = value; }
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

#if DEBUG
        public static void ExecuteForTest(Action<Data> dataInspectionCallback)
        {
            // Execute
            Processor processor = new Processor();
            processor.DataManager.Load();
            processor.CheckState();
            processor.State.Execute(processor);
            processor.DataManager.Save();
            // Inspect data
            if (dataInspectionCallback != null)
                dataInspectionCallback(processor.DataManager.Data);
        }
#endif
    }
}
