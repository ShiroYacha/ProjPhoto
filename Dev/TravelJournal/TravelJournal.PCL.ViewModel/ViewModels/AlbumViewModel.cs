using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;
using TravelJournal.PCL.DataService;

namespace TravelJournal.PCL.ViewModel
{
    public class AlbumViewModel : BindedViewModel
    {
        private Album album;

        public string Name
        {
            get
            {
                return album.Name;
            }
            set
            {
                if (value != album.Name)
                {
                    album.Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public DateTime TimeTag
        {
            get
            {
                return album.TimeTag;
            }
            set
            {
                if (value != album.TimeTag)
                {
                    album.TimeTag = value;
                    RaisePropertyChanged("TimeTag");
                }
            }
        }

        public List<PhotoViewModel> PhotoViewModels
        {
            get;
            private set;
        }

        public PhotoViewModel CurrentPhotoViewModel
        {
            get;set;
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData(Album album)
        {
            this.album = album;
            PhotoViewModels = new List<PhotoViewModel>();
            foreach(Photo photo in album.PhotoList)
            {
                PhotoViewModel pvm = new PhotoViewModel();
                pvm.LoadData(photo);
                PhotoViewModels.Add(pvm);
            }
            CurrentPhotoViewModel = PhotoViewModels[0];
            IsDataLoaded = true;
        }

        public void ViewOnMap()
        {
            throw new NotImplementedException();
        }

        public void ViewOnList()
        {
            NavigateTo(this,"AlbumListPage");
        }

        public List<KeyedList<string, PhotoViewModel>> GroupedPhotos
        {
            get
            {
                var photos = PhotoViewModels;

                var groupedPhotos =
                    from photo in photos
                    orderby photo.Position.GpsPoint.Timestamp
                    group photo by photo.Position.GpsPoint.Timestamp.ToString("y") into photosByMonth
                    select new KeyedList<string, PhotoViewModel>(photosByMonth);

                return new List<KeyedList<string, PhotoViewModel>>(groupedPhotos);
            }
        }

        public ICommand OnSelectPhoto
        {
            get
            {
                return new RelayCommand<PhotoViewModel>(SelectPhoto);
            }
        }

        public void SelectPhoto(PhotoViewModel photoViewModel)
        {
            this.CurrentPhotoViewModel = photoViewModel;
            NavigateTo(this);
        }
    }
    public class KeyedList<TKey, TItem> : List<TItem>
    {
        public TKey Key { protected set; get; }

        public KeyedList(TKey key, IEnumerable<TItem> items)
            : base(items)
        {
            Key = key;
        }

        public KeyedList(IGrouping<TKey, TItem> grouping)
            : base(grouping)
        {
            Key = grouping.Key;
        }
    }
}