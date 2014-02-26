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
    public class ConnectivityTesterAgent : ConnectivityTesterAgentBase
    {

        public override string Name { get { return "NAME_CONNECTIVITY_TEST_AGENT"; } }
        public override void Start()
        {
            PeriodicTask task = null;
            task = ScheduledActionService.Find(Name) as PeriodicTask;
            if (task != null)
                ScheduledActionService.Remove(task.Name);
            else
            {
                task = new PeriodicTask(Name);
                task.Description = "Periodic test on connectivity with the simulator server.";
            }
            ScheduledActionService.Add(task);
            ScheduledActionService.LaunchForTest(Name, TimeSpan.FromSeconds(5));
            // Log
            ConnectionServiceClient serviceClient = new ConnectionServiceClient();
            serviceClient.LogAsync(LogType.Info, "Connectivity scheduled task started...", "Start", @"D:\ComputerProgramming\C#\ProjPhoto\Dev\TravelJournal\TravelJournal.PCL\.Test\ServerConnectivityTester", 30);
        }

        public override void Stop()
        {
            PeriodicTask task = null;
            task = ScheduledActionService.Find(Name) as PeriodicTask;
            if (task != null)
                ScheduledActionService.Remove(task.Name);
            // Log
            ConnectionServiceClient serviceClient = new ConnectionServiceClient();
            serviceClient.LogAsync(LogType.Info, "Connectivity scheduled task stopped...", "Start", @"D:\ComputerProgramming\C#\ProjPhoto\Dev\TravelJournal\TravelJournal.PCL\.Test\ServerConnectivityTester", 30);
        }

        public override bool OnInvoke(Action onCompleteHandler=null)
        {
            Random random = new Random();
            RequestDownloadTest(random.Next(0, 100000), () =>
            {
                ScheduledActionService.LaunchForTest(Name, TimeSpan.FromSeconds(30));
                if (onCompleteHandler!=null) onCompleteHandler();
            });
            return true;
        }
    }
}
