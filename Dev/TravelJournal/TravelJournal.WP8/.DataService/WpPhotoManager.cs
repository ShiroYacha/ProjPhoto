using Microsoft.Phone.Maps.Services;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.DataService;
using Windows.Devices.Geolocation;

namespace TravelJournal.WP8.DataService
{
    public class WpPhotoManager:IPhotoManager
    {
        public void ProceedRawPhoto(DateTime tag, Action<Photo> onPhotoFoundHandler)
        {

        }
        public bool CheckRawPhoto(DateTime tag) { return false; }

        public System.IO.Stream GetPhotoStream(string name)
        {
            using (var library = new MediaLibrary())
            {
                PictureAlbumCollection allAlbums = library.RootPictureAlbum.Albums;
                PictureAlbum cameraRoll = allAlbums.Where(album => album.Name == "Camera Roll").FirstOrDefault();
                return cameraRoll.Pictures.Where(photo => photo.Name == name).FirstOrDefault().GetImage();
            }
        }
    }
}
