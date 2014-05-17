using GalaSoft.MvvmLight.Ioc;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.BusinessLogic;
using TravelJournal.PCL.DataService;
using TravelJournal.PCL.ServiceReference;
using TravelJournal.PCL.Test;
using TravelJournal.WP8.DataService;

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

        protected override Action<string> SetupProcessor(PCL.BusinessLogic.Processor processor)
        {
            // Mock update photo handler
            QueryPhotos(default(DateTime), (result) => { (processor.PhotoManager as MockPhotoManager).LoadMockPhotos(WrapPhotoList(result)); });
            // Mock user information
            processor.DataManager.Data.UserInfo = new PCL.DataService.UserInfo()
            {
                OriginalPosition = new PCL.DataService.GpsPosition("France", "Metz", null),
                UserName = "Jimmy"
            };
            // Setup album complete handler
            processor.AlbumCompletedCallback = this.AlbumCompletedCallback;
            // Mock state machine monitor handler
            return UpdateStateMachineHandler;
        }

        private void AlbumCompletedCallback(Processor processor)
        {
            ShellToast toast = new ShellToast();
            toast.Title = "TravelJournal ";
            toast.Content = string.Format("A new album of {0} photos have been created",processor.Album.PhotoList.Count);
            toast.NavigationUri = new System.Uri("/Views/AlbumCompletedLinkerPage.xaml", UriKind.RelativeOrAbsolute);
            toast.Show();
        }

        private void UpdateStateMachineHandler(string state)
        {
            SimulationServicesClient serviceClient = new SimulationServicesClient();
            serviceClient.UpdateStateMachineAsync(state);
        }

    }
}
