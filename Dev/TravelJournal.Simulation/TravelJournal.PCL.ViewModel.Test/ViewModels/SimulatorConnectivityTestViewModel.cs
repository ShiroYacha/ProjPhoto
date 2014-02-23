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

        private long testPackageSize=0;
        public long TestPackageSize
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
                return new RelayCommand(ConnectServerAsync);
            }
        }
        public void ConnectServerAsync()
        {
            tester.ConnectServer((result) => { ConnectionStatus = result; });
        }

        public ICommand SendTestPackageRequest
        {
            get
            {
                return new RelayCommand(SendTestPackage);
            }
        }
        public void SendTestPackage()
        {
            tester.RequestDownloadTest(testPackageSize);
        }
    }
}
