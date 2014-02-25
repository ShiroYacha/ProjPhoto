using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TravelJournal.PCL.Test;

namespace TravelJournal.PCL.ViewModel.Test
{

    public class SimulatorConnectivityTestViewModel : ServerTestItemViewModelBase
    {
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

        public ICommand SendTestPackageRequest
        {
            get
            {
                return new RelayCommand(() => { (serverBase as SimulatorConnectivityTester).RequestDownloadTest(testPackageSize); });
            }
        }

        protected override ServerBase CreateServerTester()
        {
            return new SimulatorConnectivityTester();
        }
    }
}
