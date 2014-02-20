using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace TravelJournal.PCL.ViewModel.Test
{
    public class MainViewModel : BindedViewModel
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<TestItemViewModelBase>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<TestItemViewModelBase> Items { get; private set; }

        public ICommand OnLoad
        {
            get
            {
                return new RelayCommand(LoadData);
            }
        }

        private bool IsDataLoaded
        {
            get;
            set;
        }

        private void LoadData()
        {
            if (!IsDataLoaded)
            {
                // Simulator connectivity test
                TestItemViewModelBase connectivityTest = ServiceLocator.Current.GetInstance<SimulatorConnectivityTestViewModel>();
                connectivityTest.ID = "0";
                connectivityTest.LineOne = "Connectivity";
                connectivityTest.LineTwo = "Simulator connectivity test.";
                connectivityTest.LineThree = "Upload/download speed, accessibility and robustness test.";
                this.Items.Add(connectivityTest);

                // Travel journal generation test
                TestItemViewModelBase journalGenerationTest = ServiceLocator.Current.GetInstance<JournalGenerationTestViewModel>();
                journalGenerationTest.ID = "1";
                journalGenerationTest.LineOne = "Journal generation";
                journalGenerationTest.LineTwo = "Travel journal generation test.";
                journalGenerationTest.LineThree = "Real-time journal generation test. ";
                this.Items.Add(journalGenerationTest);


                this.IsDataLoaded = true;
            }
        }
    }
}