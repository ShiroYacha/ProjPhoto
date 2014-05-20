using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TravelJournal.PCL.DataService;
using GalaSoft.MvvmLight.Ioc;
using TravelJournal.PCL.ViewModel;
using TravelJournal.WP8.DataService;
using Microsoft.Phone.Net.NetworkInformation;

namespace TravelJournal.WP8.UI
{
    public partial class MainPage : PageBase
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            DataManagerBase dataBase = SimpleIoc.Default.GetInstance<DataManagerBase>();
            if (dataBase is WpSkydriveDataManager)
            {
                await (dataBase as WpSkydriveDataManager).Initialize();
                await dataBase.Load();
                var localManager = new WpIsoDataManager();
                localManager.Data = dataBase.Data;
                await localManager.Save();
            }
            else
            {
                await dataBase.Load();
            }
            Data data = dataBase.Data;
            foreach (Album album in data.AlbumsCollection)
            {
                AlbumViewModel avm = new AlbumViewModel();
                avm.LoadData(album);
                (DataContext as MainViewModel).AlbumViewModels.Add(avm);
            }   
        }

        private async void Synchronize()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                WpSkydriveDataManager dataBase = new WpSkydriveDataManager();
                await dataBase.Initialize();
                await dataBase.Load();
                var localManager = new WpIsoDataManager();
                localManager.Data = dataBase.Data;
                await localManager.Save();
            }
        }
    }
}