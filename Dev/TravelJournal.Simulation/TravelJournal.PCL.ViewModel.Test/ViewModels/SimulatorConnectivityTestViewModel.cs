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

        private bool isConnected;
        public bool IsConnected
        {
            get { return isConnected; }
            set {
                isConnected = value;
                RaisePropertyChanged("IsConnected");
            }
        }
        public ICommand OnLoad
        {
            get
            {
                return new RelayCommand(ConnectServerAsync);
            }
        }

        public void ConnectServerAsync()
        {
            //tester.ConnectServer((e) => { IsConnected = e; });
        }
    }
}
