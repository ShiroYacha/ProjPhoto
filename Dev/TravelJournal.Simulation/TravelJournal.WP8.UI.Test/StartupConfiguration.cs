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
    public static class StartupConfiguration
    {
        public static void Startup()
        {
            RegisterIocContainers();
        }

        private static void RegisterIocContainers()
        {
            SimpleIoc.Default.Register<ConnectivityTesterAgentBase, ConnectivityTesterAgent>();
            SimpleIoc.Default.Register<TravelInfoTesterAgentBase, TravelInfoTesterAgent>();
            SimpleIoc.Default.Register<JournalGenerationTesterAgentBase, JournalGenerationTesterAgent>();

            SimpleIoc.Default.Register<ServerAgentBase>(() => SimpleIoc.Default.GetInstance<ConnectivityTesterAgentBase>(),"ConnectivityTesterAgentBase");
            SimpleIoc.Default.Register<ServerAgentBase>(() => SimpleIoc.Default.GetInstance<TravelInfoTesterAgentBase>(), "TravelInfoTesterAgentBase");
            SimpleIoc.Default.Register<ServerAgentBase>(() => SimpleIoc.Default.GetInstance<JournalGenerationTesterAgentBase>(), "JournalGenerationTesterAgentBase");
        }
    }
}
