using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Controls;
using GalaSoft.MvvmLight.Messaging;
using TravelJournal.PCL.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using System.Windows;
using Microsoft.Phone.Shell;

namespace TravelJournal.WP8.UI
{
    public class PageBase:PhoneApplicationPage
    {
        public PageBase()
            : base()
        {
            this.OrientationChanged += new EventHandler<OrientationChangedEventArgs>(Page_OrientationChanged);
        }

        protected virtual String FormatViewPath(String pageName)
        {
            string path=pageName=="MainPage"?"/MainPage.xaml":string.Format("/Views/{0}.xaml", pageName);
            return path;
        }

        protected void NavigateToPage(NavigationMessage message)
        {
            string uri = FormatViewPath(message.PageName);
            if (message.ViewModel != null) PhoneApplicationService.Current.State["ViewModel"] = message.ViewModel; // Wrong view to set view model
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        // Override OnNavigatedTo to register for messages from view model
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Messenger.Default.Register<NavigationMessage>(this, this.NavigateToPage);
            // Set view model to specific one if needed
            if (PhoneApplicationService.Current.State.ContainsKey("ViewModel"))
            {
                BindedViewModel specificViewModel = PhoneApplicationService.Current.State["ViewModel"] as BindedViewModel;
                DataContext = specificViewModel;
                PhoneApplicationService.Current.State.Remove("ViewModel");
            }
        }

        // Override OnNavigatedFrom to unregister for messages from view model
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            Messenger.Default.Unregister(this);
            // Trigger the leaving event on view model
            (this.DataContext as BindedViewModel).NavigateFrom();
        }

        // Smooth rotation change for page orientation changes
        PageOrientation lastOrientation;
        void Page_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            PageOrientation newOrientation = e.Orientation;

            // Orientations are (clockwise) 'PortraitUp', 'LandscapeRight', 'LandscapeLeft'

            RotateTransition transitionElement = new RotateTransition();

            switch (newOrientation)
            {
                case PageOrientation.Landscape:
                case PageOrientation.LandscapeRight:
                    // Come here from PortraitUp (i.e. clockwise) or LandscapeLeft?
                    if (lastOrientation == PageOrientation.PortraitUp)
                        transitionElement.Mode = RotateTransitionMode.In90Counterclockwise;
                    else
                        transitionElement.Mode = RotateTransitionMode.In180Clockwise;
                    break;
                case PageOrientation.LandscapeLeft:
                    // Come here from LandscapeRight or PortraitUp?
                    if (lastOrientation == PageOrientation.LandscapeRight)
                        transitionElement.Mode = RotateTransitionMode.In180Counterclockwise;
                    else
                        transitionElement.Mode = RotateTransitionMode.In90Clockwise;
                    break;
                case PageOrientation.Portrait:
                case PageOrientation.PortraitUp:
                    // Come here from LandscapeLeft or LandscapeRight?
                    if (lastOrientation == PageOrientation.LandscapeLeft)
                        transitionElement.Mode = RotateTransitionMode.In90Counterclockwise;
                    else
                        transitionElement.Mode = RotateTransitionMode.In90Clockwise;
                    break;
                default:
                    break;
            }

            // Execute the transition
            PhoneApplicationPage phoneApplicationPage = (PhoneApplicationPage)(((PhoneApplicationFrame)Application.Current.RootVisual)).Content;
            ITransition transition = transitionElement.GetTransition(phoneApplicationPage);
            transition.Completed += delegate
            {
                transition.Stop();
            };
            transition.Begin();

            lastOrientation = newOrientation;
        }
    }
}
