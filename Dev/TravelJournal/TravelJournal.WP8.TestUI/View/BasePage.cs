using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Controls;
using GalaSoft.MvvmLight.Messaging;
using TravelJournal.PCL.ViewModel;

namespace TravelJournal.WP8.TestUI
{
    public class BasePage:PhoneApplicationPage
    {
        public BasePage():base()
        {
          
        }

        protected void NavigateToPage(NavigationMessage message)
        {
            string uri = string.Format("/View/{0}.xaml", message.PageName);
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        // Override OnNavigatedTo to register for messages from view model
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Messenger.Default.Register<NavigationMessage>(this, this.NavigateToPage);
        }

        // Override OnNavigatedFrom to unregister for messages from view model
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            Messenger.Default.Unregister(this);
        }
    }
}
