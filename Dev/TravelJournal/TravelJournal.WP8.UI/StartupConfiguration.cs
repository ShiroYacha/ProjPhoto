using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
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
using TravelJournal.WP8.UI.Test;

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
            //    SimpleIoc.Default.Register<DataManagerBase, DesignTimeDataManager>();
            //}
            //else
            //{
            //    // Create run time view services and models
            //    SimpleIoc.Default.Register<DataManagerBase,WpDataManager>();
            //}
            SimpleIoc.Default.Register<DataManagerBase, WpSkydriveDataManager>();
            SimpleIoc.Default.Register<IPhotoManager, WpPhotoManager>();
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
