using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using TravelJournal.PCL.DataService;

namespace TravelJournal.PCL.ViewModel
{
    public class PhotoViewModel : BindedViewModel
    {
        private Photo photo;

        public string Name
        {
            get
            {
                return photo.Name;
            }
            set
            {
                if (value != photo.Name)
                {
                    photo.Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public GpsPosition Position
        {
            get
            {
                return photo.Position;
            }
            set
            {
                if (value != photo.Position)
                {
                    photo.Position = value;
                    RaisePropertyChanged("Position");
                }
            }
        }

        public System.IO.Stream Stream
        {
            get
            {
                return SimpleIoc.Default.GetInstance<IPhotoManager>().GetPhotoStream(photo.Name);
            }
        }

        public System.IO.Stream ThumbnailStream
        {
            get
            {
                return SimpleIoc.Default.GetInstance<IPhotoManager>().GetPhotoThumbnailStream(photo.Name);
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData(Photo photo)
        {
            this.photo = photo;
        }
    }
}