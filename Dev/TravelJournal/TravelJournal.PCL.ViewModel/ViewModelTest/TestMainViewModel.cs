using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace TravelJournal.PCL.ViewModel
{
    public class TestMainViewModel : ViewModelBase
    {
        public TestMainViewModel()
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

        public ICommand OnSelectTestItem
        {
            get
            {
                return new RelayCommand<Object>(NavigateToTestItem);
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
                TestItemViewModelBase target = ServiceLocator.Current.GetInstance<JournalGenerationTestViewModel>();
                target.ID = "0";
                target.LineOne = "Journal generation";
                target.LineTwo = "Travel journal generation test.";
                target.LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu";
                this.Items.Add(target);

                this.IsDataLoaded = true;
            }
        }

        private void NavigateToTestItem(object navigateItem)
        {
            Messenger.Default.Send(new NavigationMessage((navigateItem as TestItemViewModelBase).ViewXamlName));
        }
    }
}