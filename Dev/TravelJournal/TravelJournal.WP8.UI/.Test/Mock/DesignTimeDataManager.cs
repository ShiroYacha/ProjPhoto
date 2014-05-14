using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.BusinessLogic;
using TravelJournal.PCL.DataService;
using TravelJournal.WP8.BusinessLogic;
using TravelJournal.WP8.DataService;

namespace TravelJournal.WP8.UI.Test
{
    public class DesignTimeDataManager:DataManagerBase
    {
        public override void Load()
        {
            Data = new Data();
            List<Album> albumList = new List<Album>();
            albumList.Add(new Album()
                {
                    Name="Test album 1",
                    TimeTag=DateTime.Parse("7:00:00 2012/9/12"),
                    PhotoList = new List<Photo>(GetSamplePhotos(40))
                });
            Data.AlbumsCollection = albumList;
        }

        private List<Photo> GetSamplePhotos(int count)
        {
            List<Photo> photos=new List<Photo>();
            using (var library = new Microsoft.Xna.Framework.Media.MediaLibrary())
            {
                Microsoft.Xna.Framework.Media.PictureAlbumCollection allAlbums = library.RootPictureAlbum.Albums;
                Microsoft.Xna.Framework.Media.PictureAlbum cameraRoll = allAlbums.Where(album => album.Name == "Camera Roll").FirstOrDefault();
                IEnumerable<Microsoft.Xna.Framework.Media.Picture> photoStreams = cameraRoll.Pictures.Reverse().Skip(6).Take(count);
                IExifExtractor extractor=new ExifLibExtractor();
                IWebService webService = new WpWebService();
                // Create photos
                foreach(Microsoft.Xna.Framework.Media.Picture photoStream in photoStreams)
                {
                    Photo photo = new Photo();
                    photo.Name = photoStream.Name;
                    GpsPoint p = extractor.ExtractGeoCoordinate(photo);
                    photo.Position = new GpsPosition("", "", p);
                    //photo.Position = webService.GetGeoposition(p).Result;
                    photos.Add(photo);
                }
            }
            return photos;
        }

        public override void Save()
        {
            
        }
    }
}
