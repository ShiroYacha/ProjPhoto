using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.WP8.DataService;

namespace TravelJournal.WP8.DataService.Tests
{
    [TestClass()]
    public class WpPhotoManagerTests
    {
        [TestMethod()]
        public void GetPhotoStreamTest()
        {
            // Arrange
            WpPhotoManager wp = new WpPhotoManager();
            // Act
            Stream stream=wp.GetPhotoStream("WP_20131201_13_37_04_Pro.jpg");
            // Assert
            Assert.IsNotNull(stream);
        }
    }
}
