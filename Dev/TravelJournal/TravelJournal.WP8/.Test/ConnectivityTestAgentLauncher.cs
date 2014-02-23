using Microsoft.Phone.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TravelJournal.PCL.Test;
using TravelJournal.PCL.ServiceReference;

namespace TravelJournal.WP8.Test
{
    public class ConnectivityTestAgentLauncher:IPeriodicAgentLauncher
    {
        public void Start()
        {
            PeriodicTask task = null;
            task = ScheduledActionService.Find(ScheduledAgent.NAME_CONNECTIVITY_TEST_AGENT) as PeriodicTask;
            if (task != null)
                ScheduledActionService.Remove(task.Name);
            else
            {
                task = new PeriodicTask(ScheduledAgent.NAME_CONNECTIVITY_TEST_AGENT);
                task.Description = "Periodic test on connectivity with the simulator server.";
            }
            ScheduledActionService.Add(task);
            ScheduledActionService.LaunchForTest(ScheduledAgent.NAME_CONNECTIVITY_TEST_AGENT, TimeSpan.FromSeconds(5));
            // Log
            ConnectionServiceClient serviceClient = new ConnectionServiceClient();
            serviceClient.LogAsync(LogType.Info, "Connectivity scheduled task started...", "Start", @"D:\ComputerProgramming\C#\ProjPhoto\Dev\TravelJournal\TravelJournal.PCL\.Test\ServerConnectivityTester", 30);
        }


    }
}
