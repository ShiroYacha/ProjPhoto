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
    public class JournalGenerationTesterAgent:JournalGenerationTesterAgentBase
    {
        public override string Name
        {
            get { return "NAME_JOURNAL_GENERATION_TESTER_AGENT"; }
        }

        public override string Description
        {
            get { return "Generate travel journals based on simulated photos and travel."; }
        }

        public override void Start()
        {
            ScheduledAgent.StartTaskForTest(Name, Description);
            // Log
            SimulationServicesClient serviceClient = new SimulationServicesClient();
            serviceClient.LogAsync(LogType.Info, "Journal generation scheduled task starting...", "Start", @"D:\ComputerProgramming\C#\ProjPhoto\Dev\TravelJournal\TravelJournal.PCL\.Test\JournalGenerationTesterAgent", 29);
        }

        public override void Stop()
        {
            PeriodicTask task = null;
            task = ScheduledActionService.Find(Name) as PeriodicTask;
            if (task != null)
                ScheduledActionService.Remove(task.Name);
            // Log
            SimulationServicesClient serviceClient = new SimulationServicesClient();
            serviceClient.LogAsync(LogType.Info, "Journal generation scheduled task stopping...", "Stop", @"D:\ComputerProgramming\C#\ProjPhoto\Dev\TravelJournal\TravelJournal.PCL\.Test\JournalGenerationTesterAgent", 40);
        }

        protected override Action<string> MockSetupProcessor(PCL.BusinessLogic.Processor processor)
        {
            // Mock update photo handler
            (processor.PhotoManager as MockPhotoManager).UpdatePhotoHandler = (photos, tag) =>
                {
                    QueryPhotos(tag, (result) => { photos = WrapPhotoList(result); });
                };
            // Mock user information
            processor.DataManager.Data.UserInfo = new PCL.DataService.UserInfo()
            {
                OriginalPosition = new PCL.DataService.GpsPosition("France", "Metz", null),
                UserName = "Jimmy"
            };
            // Mock state machine monitor handler
            return null;
        }
    }
}
