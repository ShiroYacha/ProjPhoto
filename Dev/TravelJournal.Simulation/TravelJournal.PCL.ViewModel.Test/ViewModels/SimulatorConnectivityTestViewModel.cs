using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TravelJournal.PCL.Test;

namespace TravelJournal.PCL.ViewModel.Test
{

    public class SimulatorConnectivityTestViewModel : TestItemViewModelBase
    {
        private ServerConnectivityTester tester = new ServerConnectivityTester();

        private ConnectionStatus connectionStatus=ConnectionStatus.Disconnected;
        public ConnectionStatus ConnectionStatus
        {
            get { return connectionStatus; }
            set 
            {
                if (connectionStatus != value)
                {
                    connectionStatus = value;
                    RaisePropertyChanged("ConnectionStatus");
                }
            }
        }

        private int testPackageSize=0;
        public int TestPackageSize
        {
            get { return testPackageSize; }
            set
            {
                if (testPackageSize != value)
                {
                    testPackageSize = value;
                    RaisePropertyChanged("TestPackageSize"); 
                }
            }
        }

        public ICommand ConnectServer
        {
            get
            {
                return new RelayCommand(() => { tester.ConnectServer((result) => { ConnectionStatus = result; }); });
            }
        }

        public ICommand SendTestPackageRequest
        {
            get
            {
                return new RelayCommand(() => { tester.RequestDownloadTest(testPackageSize); });
            }
        }

        public ICommand RunScheduledAgent
        {
            get
            {
                return new RelayCommand(() => { tester.StartTestPeriodicAgent(); });
            }
        }
    }
}
