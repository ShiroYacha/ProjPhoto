using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

        public ObservableCollection<PhotoViewModel> PhotoViewModels
        {
            get;
            private set;
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData(Album album)
        {
            this.album = album;
            PhotoViewModels = new ObservableCollection<PhotoViewModel>();
            foreach(Photo photo in album.PhotoList)
            {
                PhotoViewModel pvm = new PhotoViewModel();
                pvm.LoadData(photo);
                PhotoViewModels.Add(pvm);
            }
            IsDataLoaded = true;
        }

    }
}