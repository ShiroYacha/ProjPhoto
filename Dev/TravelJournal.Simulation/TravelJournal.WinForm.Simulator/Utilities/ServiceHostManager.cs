using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.WinForm.Simulator.Controls;

namespace TravelJournal.WinForm.Simulator
{
    public class ServiceHostManager
    {
        private ServiceHost host;

        public void Open()
        {
            if (host == null)
            {
                host = new ServiceHost("http://169.254.80.80:8733/Design_Time_Addresses/TravelJournal.WCF.SimulatorService/Service1/");
                host.Open();
                TravelJournalGenerationSimulation.Log(LogType.Info, "Host opened...");
            }
        }

        public void Close()
        {
            if (host != null)
            {
                host.Close();
                host = null;
                TravelJournalGenerationSimulation.Log(LogType.Info, "Host closed...");
            }
        }
    }
}
