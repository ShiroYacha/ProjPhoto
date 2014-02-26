using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TravelJournal.PCL.Test;

namespace TravelJournal.PCL.ViewModel.Test
{
    public abstract class ServerTestItemViewModelBase : TestItemViewModelBase
    {
        protected ServerAgentBase serverAgentBase;

        public ServerTestItemViewModelBase()
        {
            serverAgentBase = CreateServerAgentTester();
        }

        protected abstract ServerAgentBase CreateServerAgentTester();

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
                return new RelayCommand(() => { serverAgentBase.ConnectServer((result) => { ConnectionStatus = result; }); });
            }
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
            if (ScheduledTaskNotStarted)
            {
                ScheduledTaskNotStarted = false;
                serverAgentBase.Start();
            }
            else
            {
                ScheduledTaskNotStarted = true;
                serverAgentBase.Stop();
            }
        }
    }
}
