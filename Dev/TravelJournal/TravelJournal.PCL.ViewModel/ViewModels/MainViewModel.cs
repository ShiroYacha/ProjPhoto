using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TravelJournal.PCL.DataService;

namespace TravelJournal.PCL.ViewModel
{
    public class MainViewModel : BindedViewModel
    {
        public MainViewModel()
        {
            this.AlbumViewModels = new ObservableCollection<AlbumViewModel>();
        }

        public ObservableCollection<AlbumViewModel> AlbumViewModels { get; private set; }

        public ICommand OnLoad
        {
            get
            {
                return new RelayCommand(LoadData);
            }
        }
        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            if (!IsDataLoaded)
            {
                DataManagerBase dataBase = SimpleIoc.Default.GetInstance<DataManagerBase>();
                dataBase.Load();
                Data data = dataBase.Data;
                foreach (Album album in data.AlbumsCollection)
                {
                    AlbumViewModel avm = new AlbumViewModel();
                    avm.LoadData(album);
                    AlbumViewModels.Add(avm);
                }
                this.IsDataLoaded = true;
            }
        }

    }
}