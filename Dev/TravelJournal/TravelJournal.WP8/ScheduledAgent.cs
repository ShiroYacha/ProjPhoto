using System.Diagnostics;
using System.Windows;
using Microsoft.Phone.Scheduler;
using TravelJournal.WP8.Test;
using TravelJournal.PCL.Test;
using System;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.Generic;

namespace TravelJournal.WP8
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        private static List<ServerAgentBase> agents;

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
            // Configs
            RegisterIocContainers();
        }

        private static void RegisterIocContainers()
        {
            SimpleIoc.Default.Register<ConnectivityTesterAgentBase, ConnectivityTesterAgent>();
            SimpleIoc.Default.Register<TravelInfoTesterAgentBase, TravelInfoTesterAgent>();
            SimpleIoc.Default.Register<JournalGenerationTesterAgentBase, JournalGenerationTesterAgent>();

            SimpleIoc.Default.Register<ServerAgentBase>(() => SimpleIoc.Default.GetInstance<ConnectivityTesterAgentBase>(), "ConnectivityTesterAgentBase");
            SimpleIoc.Default.Register<ServerAgentBase>(() => SimpleIoc.Default.GetInstance<TravelInfoTesterAgentBase>(), "TravelInfoTesterAgentBase");
            SimpleIoc.Default.Register<ServerAgentBase>(() => SimpleIoc.Default.GetInstance<JournalGenerationTesterAgentBase>(), "JournalGenerationTesterAgentBase");

            agents = new List<ServerAgentBase>(SimpleIoc.Default.GetAllInstances<ServerAgentBase>());
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
            ServerAgentBase agent = agents.Find((ag) => { return ag.Name == task.Name; });
            if(agent!=null)  waitAsync =agent.OnInvoke(NotifyComplete);
            if (!waitAsync) NotifyComplete();
        }

    }
}