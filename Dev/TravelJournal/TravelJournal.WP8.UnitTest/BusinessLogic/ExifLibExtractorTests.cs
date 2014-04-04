using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.DataService;
using TravelJournal.WP8.BusinessLogic;
using TravelJournal.WP8.UnitTest;

namespace TravelJournal.WP8.BusinessLogic.Tests
{
    [TestClass()]
    public class ExifLibExtractorTests
    {
        [TestMethod()]
        public void ExtractGeoCoordinateTest()
        {
            // Arrange
            ExifLibExtractor extractor = new ExifLibExtractor();
            MediaSource mediaSource = MediaSource.GetAvailableMediaSources().First((source => source.MediaSourceType == MediaSourceType.LocalDevice));
            Picture samplePicture;
            using (MediaLibrary mediaLibrary = new MediaLibrary(mediaSource))
            {
                PictureAlbum cameraRollAlbum = mediaLibrary.RootPictureAlbum.Albums.First((album) => album.Name == "Camera Roll");
                samplePicture = cameraRollAlbum.Pictures.First();
            }
            Photo photo = new Photo()
            {
                PhotoName = "Metz.jpg",
                Stream = samplePicture.GetImage(),
                Position = new GpsPosition() { GpsPoint = new GpsPoint() { Timestamp=DateTime.Now} }
            };
            // Act
            GpsPoint point = extractor.ExtractGeoCoordinate(photo);
            // Assert
            Assert.AreNotEqual(default(double),point.Latitude);
            Assert.AreNotEqual(default(double), point.Longitude);
        }
    }
}
