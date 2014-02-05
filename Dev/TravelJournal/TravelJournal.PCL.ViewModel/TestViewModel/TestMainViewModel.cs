using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;

namespace TravelJournal.PCL.ViewModel
{
    public class TestMainViewModel : ViewModelBase
    {
        public TestMainViewModel()
        {
            this.Items = new ObservableCollection<TestItemViewModel>();
            LoadData();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<TestItemViewModel> Items { get; private set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data

            TestItemViewModel target=ServiceLocator.Current.GetInstance<TestItemViewModel>();
            target.ID= "0";
            target.LineOne = "Journal generation";
            target.LineTwo = "Travel journal generation test.";
            target.LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu";
            this.Items.Add(target);       

            this.IsDataLoaded = true;
        }

    }
}