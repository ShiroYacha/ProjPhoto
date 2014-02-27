using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Controls;
using GalaSoft.MvvmLight.Messaging;
using TravelJournal.PCL.ViewModel;
using GalaSoft.MvvmLight.Ioc;

namespace TravelJournal.WP8.UI.Test
{
    public class PageBase:PhoneApplicationPage
    {
        public PageBase()
            : base()
        {
        }

        protected virtual String FormatViewPath(String pageName)
        {
            string path=pageName=="MainPage"?"/MainPage.xaml":string.Format("/Views/{0}.xaml", pageName);
            return path;
        }

        protected void NavigateToPage(NavigationMessage message)
        {
            string uri = FormatViewPath(message.PageName);
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
            // Trigger the leaving event on view model
            (this.DataContext as BindedViewModel).NavigateFrom();
        }

    }
}
