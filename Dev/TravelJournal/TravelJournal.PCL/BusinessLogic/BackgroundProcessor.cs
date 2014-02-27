using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.DataService;
using System.Threading;

namespace TravelJournal.PCL.BusinessLogic
{
    class BackgroundProcessor
    {
       
        private DateTime nowTime;
        private IWebService webService;
        private DataManagerBase dataManager;
        private IPhotoOrganizer photoOrganizer;
        private Album album;
        private IPhotoManager photoManager;
        private IExifExtractor exifExtractor;
        
        public BackgroundProcessor()
        {
            dataManager = SimpleIoc.Default.GetInstance<DataManagerBase>();
            photoOrganizer = SimpleIoc.Default.GetInstance<PhotoOrganizer>();
            dataManager = SimpleIoc.Default.GetInstance<DataManagerBase>();
            photoManager = SimpleIoc.Default.GetInstance<IPhotoManager>();
            exifExtractor = SimpleIoc.Default.GetInstance<IExifExtractor>();
        }

        public void Execute()
        {
            nowTime = DateTime.Now;
            webService = SimpleIoc.Default.GetInstance<IWebService>();
            GpsPoint p = webService.GetUserPosition();
            album = dataManager.GetAlbum();
            photoManager.FoundRawPhoto(album.GetTimeTag(), PhotoHandler);   
        }

        public void PhotoHandler(Photo aPhoto)
        {
            GpsPoint p = exifExtractor.ExtractGeoCoordinate(aPhoto);
            aPhoto.Position = webService.GetGeoposition(p);
            photoOrganizer.OrganizePhoto(aPhoto, album);
            dataManager.Save();
        }       
    }
}
