using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using TravelJournal.PCL.DataService;

namespace TravelJournal.WP8.Test
{
    public class MockPhotoManager:IPhotoManager
    {
        private List<Photo> photos=new List<Photo>();

        public void LoadMockPhotos(List<Photo> photos)
        {
            this.photos = photos;
        }

        public void ProceedRawPhoto(DateTime tag, Action<Photo> onPhotoFoundHandler)
        {
            foreach (Photo photo in photos.Where((p) => { return p.Position.GpsPoint.Timestamp > tag; }))
            {
                if (onPhotoFoundHandler != null)
                    onPhotoFoundHandler(photo);
            }
        }

        public bool CheckRawPhoto(DateTime tag)
        {
            return photos.Any((p) => { return p.Position.GpsPoint.Timestamp > tag; });
        }


        public System.IO.Stream GetPhotoStream(string name)
        {
            // Create informative mock image
            List<string> contents = new List<string>();
            contents.Add(name);
            contents.AddRange(GetPhotoInfo(name));
            return DrawStringOnBitmap(name,800, 600, 50, contents.ToArray());
        }

        public System.IO.Stream GetPhotoThumbnailStream(string name)
        {
            // Create informative mock image
            return DrawStringOnBitmap(name,400, 300, 25, name);
        }

        private List<string> GetPhotoInfo(string name)
        {
            var photoManager= SimpleIoc.Default.GetInstance<DataManagerBase>();
            var position = photoManager.Data.AlbumsCollection.FirstOrDefault().PhotoList.FirstOrDefault((photo) => { return photo.Name == name; }).Position;
            return new List<string>(){
                string.Format("County: {0} City: {1}", position.Country, position.City), 
                string.Format("Time: {0}", position.GpsPoint.Timestamp),
                string.Format("GPS: ({0:0.00000}|{1:0.00000})", position.GpsPoint.Latitude, position.GpsPoint.Longitude)};
        }
        
        private System.IO.Stream DrawStringOnBitmap(string name,int width,int height,int fontSize,params string[] contents)
        {
            MemoryStream memoryStream = new MemoryStream();
            WriteableBitmap wb = new WriteableBitmap(width, height);
            // Render background
            Random ran = new Random();
            wb.Render(new Canvas() { Background = new SolidColorBrush(GetMockBackgroundColor(name)), Width = width, Height = height }, null);
            // Render text
            TextBlock tb = new TextBlock();
            tb.Foreground = new SolidColorBrush(Colors.White);
            tb.FontSize = fontSize;
            TranslateTransform tf = new TranslateTransform();
            for (int i = 0; i < Math.Min(contents.Length, 5); i++)
            {
                tb.Text = contents[i];
                tf.X = 30;
                tf.Y = 40+fontSize*1.5*i;
                wb.Render(tb, tf);
            }
            wb.Invalidate();
            wb.SaveJpeg(memoryStream, wb.PixelWidth, wb.PixelHeight, 0, 100);
            memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
            return memoryStream;
        }

        private Dictionary<string, Color> mockBackgroundColors = new Dictionary<string, Color>();
        private Color GetMockBackgroundColor(string name)
        {
            if(mockBackgroundColors.ContainsKey(name))
                return mockBackgroundColors[name];
            else
            {
                Random ran = new Random();
                Color color = Color.FromArgb((byte)(ran.NextDouble() * 255), (byte)(ran.NextDouble() * 255), (byte)(ran.NextDouble() * 255), (byte)(ran.NextDouble() * 255));
                mockBackgroundColors.Add(name,color);
                return color;
            }

        }


        public DateTime GetPhotoTimestamp(string name)
        {
            return default(DateTime);
        }


    }
}
