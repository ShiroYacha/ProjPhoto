using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.WP8.DataService;
using TravelJournal.PCL.DataService;

namespace TravelJournal.WP8.DataService.Tests
{
    [TestClass()]
    public class WpDataManagerTests
    {
        [TestMethod()]
        public void SaveLoadTest()
        {
             // Arrange
            WpIsoDataManager dataManager = new WpIsoDataManager();
            Data data = new Data() { TouristCity = new List<string> {"Metz","Paris","Lille","Leyon" }, State=new TravelJournal.PCL.BusinessLogic.PilotState()};
            dataManager.Data = data;
            //Act
            dataManager.Save();
            dataManager.Data = null;
            dataManager.Load();
            //Assert
            CollectionAssert.AreEqual(dataManager.Data.TouristCity, data.TouristCity);
            Assert.AreEqual(dataManager.Data.State.GetType().Name, "PilotState");
        }

    }
}
