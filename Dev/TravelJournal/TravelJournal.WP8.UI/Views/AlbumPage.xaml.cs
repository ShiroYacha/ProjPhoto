using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TravelJournal.PCL.ViewModel;
using System.Windows.Media;
using Microsoft.Xna.Framework.Input.Touch;

namespace TravelJournal.WP8.UI
{
    public partial class AlbumPage : PageBase
    {
        const double MaxScale = 10;

        double scale = 1.0;
        double minScale;
        double coercedScale;
        double originalScale;
        double initialScale;

        Size viewportSize;
        bool pinching;
        Point screenMidpoint;
        Point relativeMidpoint;

        BitmapImage bitmap; 

        public AlbumPage():base()
        {
            InitializeComponent();
            TouchPanel.EnabledGestures = GestureType.Flick;
        }

        private void ViewOnMapButton_Click(object sender, EventArgs e)
        {
            var vm = DataContext as AlbumViewModel;
            if (vm != null)
            {
                vm.ViewOnMap();
            }
        }

        private void ViewOnListButton_Click(object sender, EventArgs e)
        {
            var vm = DataContext as AlbumViewModel;
            if (vm != null)
            {
                vm.ViewOnList();
            }
        }

        void InitializeImage(PhotoViewModel photoViewModel)
        {
            bitmap = new BitmapImage();
            bitmap.SetSource(photoViewModel.Stream);

            // Test overlay image on stream
            WriteableBitmap writeableBitmap = new WriteableBitmap(bitmap);
            //Just to make sure the boundary is correct so I draw the green rec around the object
            writeableBitmap.Invalidate();

            // Set source to image
            TestImage.Source = writeableBitmap;

            // Set scale to the minimum, and then save it. 
            scale = 0;
            CoerceScale(true);
            scale = coercedScale;

            initialScale = scale;

            ResizeImage(true);
        }

        /// <summary> 
        /// Either the user has manipulated the image or the size of the viewport has changed. We only 
        /// care about the size. 
        /// </summary> 
        #region Pinch and zoom
        void viewport_ViewportChanged(object sender, System.Windows.Controls.Primitives.ViewportChangedEventArgs e)
        {
            Size newSize = new Size(viewport.Viewport.Width, viewport.Viewport.Height);
            if (newSize != viewportSize)
            {
                viewportSize = newSize;
                CoerceScale(true);
                ResizeImage(false);
            }
        }

        /// <summary> 
        /// Handler for the ManipulationStarted event. Set initial state in case 
        /// it becomes a pinch later. 
        /// </summary> 
        void OnManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            pinching = false;
            originalScale = scale;
        }

        /// <summary> 
        /// Handler for the ManipulationDelta event. It may or may not be a pinch. If it is not a  
        /// pinch, the ViewportControl will take care of it. 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        void OnManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            if (e.PinchManipulation != null)
            {
                e.Handled = true;

                if (!pinching)
                {
                    pinching = true;
                    Point center = e.PinchManipulation.Original.Center;
                    relativeMidpoint = new Point(center.X / TestImage.ActualWidth, center.Y / TestImage.ActualHeight);

                    var xform = TestImage.TransformToVisual(viewport);
                    screenMidpoint = xform.Transform(center);
                }

                scale = originalScale * e.PinchManipulation.CumulativeScale;

                CoerceScale(false);
                ResizeImage(false);
            }
            else if (pinching)
            {
                pinching = false;
                originalScale = scale = coercedScale;
            }
        }

        /// <summary> 
        /// The manipulation has completed (no touch points anymore) so reset state. 
        /// </summary> 
        void OnManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            if (scale != initialScale)
            {
                pinching = false;
                scale = coercedScale;
            }
            else if (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                switch (gesture.GestureType)
                {
                    case GestureType.Flick:
                        AlbumViewModel albumViewModel =DataContext as AlbumViewModel;
                        int currentIndex = albumViewModel.PhotoViewModels.IndexOf(albumViewModel.CurrentPhotoViewModel);
                        if (e.FinalVelocities.LinearVelocity.X < 100)
                            if (currentIndex < albumViewModel.PhotoViewModels.Count - 1) albumViewModel.CurrentPhotoViewModel = albumViewModel.PhotoViewModels[currentIndex + 1];
                        if (e.FinalVelocities.LinearVelocity.X > 100)
                            if (currentIndex > 0) albumViewModel.CurrentPhotoViewModel = albumViewModel.PhotoViewModels[currentIndex - 1];
                        InitializeImage(albumViewModel.CurrentPhotoViewModel);
                        break;
                    default:
                        break;
                }
            }

        }


        /// <summary> 
        /// When a new image is opened, set its initial scale. 
        /// </summary> 
        void OnImageOpened(object sender, RoutedEventArgs e)
        {
            InitializeImage((DataContext as AlbumViewModel).CurrentPhotoViewModel);
        }

        /// <summary> 
        /// Adjust the size of the image according to the coerced scale factor. Optionally 
        /// center the image, otherwise, try to keep the original midpoint of the pinch 
        /// in the same spot on the screen regardless of the scale. 
        /// </summary> 
        /// <param name="center"></param> 
        void ResizeImage(bool center)
        {
            if (coercedScale != 0 && bitmap != null)
            {
                double newWidth = canvas.Width = Math.Round(bitmap.PixelWidth * coercedScale);
                double newHeight = canvas.Height = Math.Round(bitmap.PixelHeight * coercedScale);

                xform.ScaleX = xform.ScaleY = coercedScale;

                viewport.Bounds = new Rect(0, 0, newWidth, newHeight);

                if (center)
                {
                    viewport.SetViewportOrigin(
                        new Point(
                            Math.Round((newWidth - viewport.ActualWidth) / 2),
                            Math.Round((newHeight - viewport.ActualHeight) / 2)
                            ));
                }
                else
                {
                    Point newImgMid = new Point(newWidth * relativeMidpoint.X, newHeight * relativeMidpoint.Y);
                    Point origin = new Point(newImgMid.X - screenMidpoint.X, newImgMid.Y - screenMidpoint.Y);
                    viewport.SetViewportOrigin(origin);
                }
            }
        }

        /// <summary> 
        /// Coerce the scale into being within the proper range. Optionally compute the constraints  
        /// on the scale so that it will always fill the entire screen and will never get too big  
        /// to be contained in a hardware surface. 
        /// </summary> 
        /// <param name="recompute">Will recompute the min max scale if true.</param> 
        void CoerceScale(bool recompute)
        {
            if (recompute && bitmap != null && viewport != null)
            {
                // Calculate the minimum scale to fit the viewport 
                double minX = viewport.ActualWidth / bitmap.PixelWidth;
                double minY = viewport.ActualHeight / bitmap.PixelHeight;

                minScale = Math.Min(minX, minY);
            }

            coercedScale = Math.Min(MaxScale, Math.Max(scale, minScale));

        } 
        #endregion
    }
}