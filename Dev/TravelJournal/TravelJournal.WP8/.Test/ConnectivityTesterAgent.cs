using Microsoft.Phone.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.ServiceReference;
using TravelJournal.PCL.Test;


namespace TravelJournal.WP8.Test
{
    public class ConnectivityTesterAgent : ConnectivityTesterAgentBase
    {
        public override string Name { get { return "NAME_CONNECTIVITY_TEST_AGENT"; } }
        public override string Description { get { return "Periodic test on connectivity with the simulator server."; } }
        public override void Start()
        {
            ScheduledAgent.StartTaskForTest(Name, Description);
            // Log
            SimulationServicesClient serviceClient = new SimulationServicesClient();
            serviceClient.LogAsync(LogType.Info, "Connectivity scheduled task starting...", "Start", @"D:\ComputerProgramming\C#\ProjPhoto\Dev\TravelJournal\TravelJournal.PCL\.Test\ConnectivityTesterAgent", 23);
        }

        public override void Stop()
        {
            PeriodicTask task = null;
            task = ScheduledActionService.Find(Name) as PeriodicTask;
            if (task != null)
                ScheduledActionService.Remove(task.Name);
            // Log
            SimulationServicesClient serviceClient = new SimulationServicesClient();
            serviceClient.LogAsync(LogType.Info, "Connectivity scheduled task stopping...", "Start", @"D:\ComputerProgramming\C#\ProjPhoto\Dev\TravelJournal\TravelJournal.PCL\.Test\ConnectivityTesterAgent", 34);
        }

        public override bool OnInvoke()
        {
            Random random = new Random();
            RequestDownloadTest(random.Next(0, 100000));
            return IsAsync;
        }
    }
}
