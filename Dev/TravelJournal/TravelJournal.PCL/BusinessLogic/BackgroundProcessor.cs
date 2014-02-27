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
        private PhotoOrganizer photoOrganizer;
        private Photo photo;
        private Album album;
        Action<Photo> photoHandlerTarget;
        private PhotoManager photoManager;
        private ExifExtractor exifExtractor;
        


        public BackgroundProcessor()
        {
            nowTime = DateTime.Now;
            webService=SimpleIoc.Default.GetInstance<IWebService>();
            GpsPoint p = webService.GetUserPosition();
            dataManager = SimpleIoc.Default.GetInstance<DataManagerBase>();
            album=dataManager.GetAlbum();
            photoOrganizer = SimpleIoc.Default.GetInstance<PhotoOrganizer>();
            

            
            photoManager = SimpleIoc.Default.GetInstance<PhotoManager>();
            exifExtractor = SimpleIoc.Default.GetInstance<ExifExtractor>();
            photoHandlerTarget = PhotoHandler;
            photoManager.FoundRawPhoto(album.getTimeTag(), photoHandlerTarget);   
        }

        public void PhotoHandler(Photo aPhoto)
        {
          GpsPoint p =  exifExtractor.ExtractGeoCoordinate(aPhoto);
          aPhoto.Position= webService.GetGeopositionAsync(p);
          photoOrganizer.OrganizePhoto(aPhoto, album);
          dataManager.Save();
           

        }       
    }
}
