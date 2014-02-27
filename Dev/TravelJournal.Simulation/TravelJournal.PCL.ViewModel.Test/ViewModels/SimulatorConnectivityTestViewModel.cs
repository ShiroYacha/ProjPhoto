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

    public class SimulatorConnectivityTestViewModel : ServerTestItemViewModelBase<ConnectivityTesterAgentBase>
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
                return new RelayCommand(() => { serverAgent.RequestDownloadTest(testPackageSize); });
            }
        }

    }
}
