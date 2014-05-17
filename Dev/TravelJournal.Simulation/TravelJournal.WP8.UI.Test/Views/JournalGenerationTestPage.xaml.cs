using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.IO;
using GalaSoft.MvvmLight.Ioc;
using TravelJournal.PCL.DataService;
using TravelJournal.WP8.DataService;

namespace TravelJournal.WP8.UI.Test
{
    public partial class JournalGenerationTestPage : PageBase
    {
        // Constructor
        public JournalGenerationTestPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            DirtyInitializeUserData();
        }

        private void DirtyInitializeUserData()
        {
            string fileName = "/shared/transfers/traveljournal/default.dat";
            using (var store = IsolatedStorageFile.GetUserStoreForApplication()) 
            {

                    if (store.FileExists(fileName)) 
                    {
                        store.DeleteFile(fileName);
                    } 
                
            } 
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