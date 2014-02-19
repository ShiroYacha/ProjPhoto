using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TravelJournal.PCL.ViewModel;
using TravelJournal.WP8.UI.Test.Resources;

namespace TravelJournal.WP8.UI.Test
{
    public partial class MainPage : PageBase
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            TestWebService();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void TestWebService()
        {
            int testValue = 7;

            ServiceReference1.Service1Client clientForTesting = new ServiceReference1.Service1Client();
            clientForTesting.GetDataCompleted += new EventHandler<ServiceReference1.GetDataCompletedEventArgs>(TestCallback);
            clientForTesting.GetDataAsync(testValue);
        }

        private void TestCallback(object sender, ServiceReference1.GetDataCompletedEventArgs e)
        {
            MessageBox.Show(e.Result);
        }
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}