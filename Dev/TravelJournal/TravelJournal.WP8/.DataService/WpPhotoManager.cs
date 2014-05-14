using Microsoft.Phone.Maps.Services;
using Microsoft.Xna.Framework.Media;
using System;
using System.IO;
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
        const int BUFFER_MAX_SIZE = 50;

        Dictionary<string, Stream> bufferedPhotoStreams = new Dictionary<string, Stream>();
        Dictionary<string, Stream> bufferedPhotoThumbnailStreams = new Dictionary<string, Stream>();


        public void ProceedRawPhoto(DateTime tag, Action<Photo> onPhotoFoundHandler)
        {

        }

        public bool CheckRawPhoto(DateTime tag) { return false; }

        public Stream GetPhotoStream(string name)
        {
            return OptimizedStreamAccess(name, bufferedPhotoStreams, (pic) => { return pic.GetImage(); });
        }

        public Stream GetPhotoThumbnailStream(string name)
        {
            return OptimizedStreamAccess(name, bufferedPhotoThumbnailStreams, (pic) => { return pic.GetThumbnail(); });
        }

        private Stream OptimizedStreamAccess(string name, Dictionary<string,Stream> bufferDictionary, Func<Picture,Stream> streamAccessor)
        {
            if (bufferDictionary.ContainsKey(name))
                return bufferDictionary[name];
            else
            {
                Stream stream = streamAccessor(GetPictureByName(name));
                bufferDictionary.Add(name, stream);
                // Clear buffer when dictionary'size exceeds the max size
                if (bufferDictionary.Count > BUFFER_MAX_SIZE)
                    bufferDictionary.Remove(bufferDictionary.Keys.First());
                return stream;
            }
        }

        public DateTime GetPhotoTimestamp(string name)
        {
            return GetPictureByName(name).Date;
        }

        private Picture GetPictureByName(string name)
        {
            using (var library = new MediaLibrary())
            {
                PictureAlbumCollection allAlbums = library.RootPictureAlbum.Albums;
                PictureAlbum cameraRoll = allAlbums.Where(album => album.Name == "Camera Roll").FirstOrDefault();
                return cameraRoll.Pictures.Where(photo => photo.Name == name).FirstOrDefault();
            }
        }



    }
}
