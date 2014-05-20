using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Phone.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using TravelJournal.PCL.BusinessLogic;
using TravelJournal.PCL.DataService;
using TravelJournal.WP8.BusinessLogic;
using TravelJournal.WP8.DataService;
using TravelJournal.WP8.Test;
using TravelJournal.WP8.UI;

namespace TravelJournal.WP8.UI
{
    public static class StartupConfiguration
    {
        public static void Startup()
        {
            RegisterIocContainers();
        }

        private async static void RegisterIocContainers()
        {
            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    // Create design time view services and models
            //    SimpleIoc.Default.Register<DataManagerBase, MockDataManager>();
            //}
            //else
            //{
            //    // Create run time view services and models
            //    SimpleIoc.Default.Register<DataManagerBase,WpDataManager>();
            //}
            
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                SimpleIoc.Default.Register<DataManagerBase,WpSkydriveDataManager>(); 
            }
            else
            {
                SimpleIoc.Default.Register<DataManagerBase,WpIsoDataManager>(); 
            }
            SimpleIoc.Default.Register<IPhotoManager, MockPhotoManager>();
            //SimpleIoc.Default.Register<DataManagerBase, WpDataManager>();
        }
    }

    public class AssociationUriMapper : UriMapperBase
    {
        private string tempUri;

        public override Uri MapUri(Uri uri)
        {
            tempUri = System.Net.HttpUtility.UrlDecode(uri.ToString());

            // URI association launch for contoso.
            if (tempUri.Contains("traveljournal:AlbumCompletedSimulation"))
            {
                // Map the show products request to ShowProducts.xaml
                return new Uri("/Views/MainPage.xaml", UriKind.Relative);
            }

            // Otherwise perform normal launch.
            return uri;
        }
    }

}
