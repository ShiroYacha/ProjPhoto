using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GalaSoft.MvvmLight.Ioc;
using TravelJournal.PCL.DataService;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;
using System.IO;
using System.Runtime.Serialization;
using TravelJournal.WP8.DataService;

namespace TravelJournal.WP8.UI.Test
{
    public partial class AlbumCompletedLinkerPage : PhoneApplicationPage
    {
        public AlbumCompletedLinkerPage()
        {
            InitializeComponent();
        }

        private async void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            await UploadIsoToSkydrive();
            await Windows.System.Launcher.LaunchUriAsync(new System.Uri("traveljournal:AlbumCompletedSimulation"));
        }

        private static string folderName = "traveljournal";
        private static string fileName = "default.dat";
        DataContractSerializer serializer = new DataContractSerializer(typeof(Data));
        private IsolatedStorageFile _isoFile;


        IsolatedStorageFile IsoFile
        {
            get
            {
                if (_isoFile == null)
                    _isoFile = IsolatedStorageFile.GetUserStoreForApplication();
                return _isoFile;
            }
        }

        private async Task UploadIsoToSkydrive()
        {
            Data data = default(Data);
            string targetFileName = string.Format("/shared/transfers/{0}/{1}", folderName, fileName);

            if (IsoFile.FileExists(targetFileName))
                using (var sourceStream =
                        IsoFile.OpenFile(targetFileName, FileMode.Open))
                {
                    data = (Data)serializer.ReadObject(sourceStream);
                }
            WpSkydriveDataManager uploader = new WpSkydriveDataManager();
            await uploader.Initialize();
            uploader.Data = data;
            await uploader.SaveAsync();
        }
    }
}