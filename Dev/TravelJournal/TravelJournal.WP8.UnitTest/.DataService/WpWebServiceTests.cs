using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.WP8.DataService;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using TravelJournal.PCL.DataService;

namespace TravelJournal.WP8.DataService.Tests
{
    [TestClass()]
    public class WpWebServiceTests
    {
        [TestMethod()]
        public void GetUserPositionTest()
        {
            // Arrange
            WpWebService webService = new WpWebService();
            // Act
            GpsPosition position = webService.GetUserPosition().Result;
            // Assert
            Assert.IsTrue(position.City!=string.Empty);
            Assert.IsTrue(position.Country!= string.Empty);
        }

        [TestMethod()]
        public void GetGeopositionTest()
        {
            // Arrange
            WpWebService webService = new WpWebService();
            // Act
            GpsPosition position = webService.GetGeoposition(new GpsPoint(){Latitude=49.120359,Longitude=6.17845}).Result;
            // Assert
            Assert.AreEqual("Lorraine", position.City);
            Assert.AreEqual("France", position.Country);
        }
    }
}
