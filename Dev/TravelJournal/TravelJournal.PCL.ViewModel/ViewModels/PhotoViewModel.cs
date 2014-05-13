using GalaSoft.MvvmLight;
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
                return null;
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