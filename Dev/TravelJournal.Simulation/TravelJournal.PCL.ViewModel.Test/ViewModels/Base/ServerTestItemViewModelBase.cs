using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TravelJournal.PCL.Test;

namespace TravelJournal.PCL.ViewModel.Test
{
    public abstract class ServerTestItemViewModelBase<T> : TestItemViewModelBase where T:ServerAgentBase
    {
        protected T serverAgent;

        public ServerTestItemViewModelBase()
        {
            serverAgent = SimpleIoc.Default.GetInstance<T>();
        }

        private ConnectionStatus connectionStatus = ConnectionStatus.Disconnected;
        public ConnectionStatus ConnectionStatus
        {
            get { return connectionStatus; }
            set
            {
                if (connectionStatus != value)
                {
                    connectionStatus = value;
                    // Raise mapped property changed event
                    RaisePropertyChanged("ConnectionStatusString");
                    RaisePropertyChanged("IsConnected");
                }
            }
        }
        public string ConnectionStatusString
        {
            get { return connectionStatus.ToString(); }
        }
        public bool IsConnected
        {
            get { return connectionStatus == ConnectionStatus.Connected; }
        }
        public ICommand ConnectServer
        {
            get
            {
                return new RelayCommand(() => 
                {
                    ConnectOrDisconnectServer();
                });
            }
        }
        private void ConnectOrDisconnectServer()
        {
            if (!IsConnected)
                serverAgent.ConnectServer((result) => { ConnectionStatus = result; });
            else
                serverAgent.DisconnectServer((result) => { ConnectionStatus = result; });
        }

        private bool scheduledTaskNotStarted = true;
        public bool ScheduledTaskNotStarted
        {
            get { return scheduledTaskNotStarted; }
            set
            {
                if (scheduledTaskNotStarted != value)
                {
                    scheduledTaskNotStarted = value;
                    RaisePropertyChanged("ScheduledTaskNotStarted");
                }
            }
        }
        public ICommand RunScheduledAgent
        {
            get
            {
                return new RelayCommand(() => { StartOrStopScheduledAgent(); });
            }
        }
        private void StartOrStopScheduledAgent()
        {
            if (scheduledTaskNotStarted)
            {
                ScheduledTaskNotStarted = false;
                serverAgent.Start();
            }
            else
            {
                ScheduledTaskNotStarted = true;
                serverAgent.Stop();
            }
        }

        public override void NavigateFrom()
        {
            base.NavigateFrom();
            // Remove the agent if started
            if(!scheduledTaskNotStarted)
            {
                ScheduledTaskNotStarted = true;
                serverAgent.Stop();
            }
            // Disconnect from the server if connected
            if(connectionStatus==ConnectionStatus.Connected)
                serverAgent.DisconnectServer((result) => { ConnectionStatus = result; });
        }
    }
}
