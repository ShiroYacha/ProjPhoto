using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private static void RegisterIocContainers()
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
            SimpleIoc.Default.Register<DataManagerBase, DesignTimeDataManager>();
            SimpleIoc.Default.Register<IPhotoManager, WpPhotoManager>();
            //SimpleIoc.Default.Register<DataManagerBase, WpDataManager>();
        }
    }
}
