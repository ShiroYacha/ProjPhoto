using Microsoft.Phone.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.ServiceReference;
using TravelJournal.PCL.Test;
using GalaSoft.MvvmLight.Messaging;

namespace TravelJournal.WP8.Test
{
    public class TravelInfoTesterAgent : TravelInfoTesterAgentBase
    {
        public override string Name
        {
            get { return "NAME_TRAVEL_INFO_TESTER_AGENT"; }
        }

        public override string Description
        {
            get { return "Accessibility test on travel information."; }
        }

        public override void Start()
        {
            ScheduledAgent.StartTaskForTest(Name, Description);
            // Log
            SimulationServicesClient serviceClient = new SimulationServicesClient();
            serviceClient.LogAsync(LogType.Info, "Travel information scheduled task starting...", "Start", @"D:\ComputerProgramming\C#\ProjPhoto\Dev\TravelJournal\TravelJournal.PCL\.Test\TravelInfoTesterAgent", 29);
        }

        public override void Stop()
        {
            PeriodicTask task = null;
            task = ScheduledActionService.Find(Name) as PeriodicTask;
            if (task != null)
                ScheduledActionService.Remove(task.Name);
            // Log
            SimulationServicesClient serviceClient = new SimulationServicesClient();
            serviceClient.LogAsync(LogType.Info, "Travel information scheduled task stopping...", "Stop", @"D:\ComputerProgramming\C#\ProjPhoto\Dev\TravelJournal\TravelJournal.PCL\.Test\TravelInfoTesterAgent", 40);
        }

        public override bool OnInvoke()
        {
            UpdateCurrentGps();
            return IsAsync;
        }



    }
}
