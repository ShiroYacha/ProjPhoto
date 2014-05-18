using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location;
using System.Windows.Media.Imaging;
using TravelJournal.PCL.ViewModel;

namespace TravelJournal.WP8.UI.Views
{
    public partial class AlbumMapPage : PageBase
    {
        public AlbumMapPage()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            SetupMapControl();
        }

        private void SetupMapControl()
        {
            AlbumViewModel viewModel = DataContext as AlbumViewModel;
            MapLayer MyLayer = new MapLayer();
            // Add all photos
            foreach (PhotoViewModel pvm in viewModel.PhotoViewModels)
            {
                // Creating a Grid element.
                Grid MyGrid = new Grid();
                MyGrid.RowDefinitions.Add(new RowDefinition());
                MyGrid.RowDefinitions.Add(new RowDefinition());
                MyGrid.Background = new SolidColorBrush(Colors.Transparent);
                Image image = new Image();
                image.Tag = pvm;
                image.Tap += image_Tap;
                image.Width = 150;
                image.Height = 150;
                BitmapImage bm = new BitmapImage();
                bm.SetSource(pvm.ThumbnailStream);
                image.Source = bm;
                MyGrid.Children.Add(image);
                // Creating a MapOverlay and adding the Grid to it.
                MapOverlay MyOverlay = new MapOverlay();
                MyOverlay.Content = MyGrid;
                var gps = pvm.Position.GpsPoint;
                MyOverlay.GeoCoordinate = new GeoCoordinate(gps.Latitude, gps.Longitude);
                MyOverlay.PositionOrigin = new Point(0.5, 0.5);
                // Add to layer
                MyLayer.Add(MyOverlay);
            }

            PhotoMap.Layers.Add(MyLayer);

            // Set center
            var centerGps = viewModel.GetAlbumGpsCentroid();
            PhotoMap.Center = new GeoCoordinate(centerGps.Latitude, centerGps.Longitude);
            // Set view 
            var boundingRectangle = viewModel.GetAlbumGpsBoundingRectangle();
            if(boundingRectangle!=null)
            {
                // use bounding rectangle
                double delta = 0.00005;
                PhotoMap.SetView(new LocationRectangle((new GeoCoordinate(boundingRectangle.Item1.Latitude + delta, boundingRectangle.Item1.Longitude - delta)),
                    new GeoCoordinate(boundingRectangle.Item2.Latitude - delta, boundingRectangle.Item2.Longitude + delta)),
                    MapAnimationKind.Parabolic);
            }
            else
            {
                // use default zoom
                PhotoMap.ZoomLevel = 14;
            }

        }

        void image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var pvm = (sender as Image).Tag as PhotoViewModel;
            var vm = (DataContext as AlbumViewModel);
            vm.CurrentPhotoViewModel = pvm;
            (DataContext as AlbumViewModel).NavigateTo(vm);
        }
    }
}