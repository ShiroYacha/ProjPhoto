using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace TravelJournal.WP8.UI.Test
{
    public partial class AlbumCompletedLinkerPage : PhoneApplicationPage
    {
        public AlbumCompletedLinkerPage()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            Windows.System.Launcher.LaunchUriAsync(new System.Uri("traveljournal:AlbumCompletedSimulation"));
        }
    }
}