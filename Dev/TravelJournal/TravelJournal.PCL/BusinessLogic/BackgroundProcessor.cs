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

        public async void Execute()
        {
            nowTime = DateTime.Now;
            webService = SimpleIoc.Default.GetInstance<IWebService>();
            //GpsPoint p = await webService.GetUserPosition();
            album = dataManager.GetAlbum("test");
            photoManager.FoundRawPhoto(album.GetTimeTag(), PhotoHandler);   
        }

        public async void PhotoHandler(Photo aPhoto)
        {
            GpsPoint p = exifExtractor.ExtractGeoCoordinate(aPhoto);
            aPhoto.Position = await webService.GetGeoposition(p,p.Timestamp);
            photoOrganizer.OrganizePhoto(aPhoto, album);
            dataManager.Save();
        }       
    }
}
