using System.Diagnostics;
using System.Windows;
using Microsoft.Phone.Scheduler;
using TravelJournal.WP8.Test;
using TravelJournal.PCL.Test;
using System;

namespace TravelJournal.WP8
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        public const string NAME_CONNECTIVITY_TEST_AGENT = "NAME_CONNECTIVITY_TEST_AGENT";

        /// <remarks>
        /// ScheduledAgent constructor, initializes the UnhandledException handler
        /// </remarks>
        static ScheduledAgent()
        {
            // Subscribe to the managed exception handler
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                Application.Current.UnhandledException += UnhandledException;
            });
        }

        /// Code to execute on Unhandled Exceptions
        private static void UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        /// <summary>
        /// Agent that runs a scheduled task
        /// </summary>
        /// <param name="task">
        /// The invoked task
        /// </param>
        /// <remarks>
        /// This method is called when a periodic or resource intensive task is invoked
        /// </remarks>
        protected override void OnInvoke(ScheduledTask task)
        {
            bool waitAsync = false;
            //TODO: Add code to perform your task in background
            switch (task.Name)
            {
                case ScheduledAgent.NAME_CONNECTIVITY_TEST_AGENT:
                    ServerConnectivityTester tester = new ServerConnectivityTester();
                    Random random=new Random();
                    tester.RequestDownloadTest(random.Next(0, 100000), () =>
                    {
                        ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(30));
                        NotifyComplete();
                    });
                    waitAsync = true;

                    break;
 
               default:
               // do nothing
               break;
            }

            if (!waitAsync) NotifyComplete();
        }

    }
}