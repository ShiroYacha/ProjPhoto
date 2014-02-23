using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.Test;
using TravelJournal.WP8.Test;

namespace TravelJournal.WP8.UI.Test
{
    public static class StartupSettings
    {
        public static void RegisterIocContainers()
        {
            SimpleIoc.Default.Register<IPeriodicAgentLauncher, ConnectivityTestAgentLauncher>();
        }
    }
}
