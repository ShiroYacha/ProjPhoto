using Microsoft.Phone.Maps.Services;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.DataService;
using Windows.Devices.Geolocation;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace TravelJournal.WP8.DataService
{
    public class WpDataManager : DataManagerBase
    {
        DataSaver<Data> myDataSaver =
              new DataSaver<Data>();
        
       
        public override void Load()
        {
            
            DataCollection = myDataSaver.LoadMyData(
                          "MyDataFileName"); 

        }
        public override void Save()
        {
            
            myDataSaver.SaveMyData(DataCollection, "MyDataFileName");
        }

    }
}
//    public override void Load()
//    {
//        XmlWriterSettings xmlwriterSettings = new XmlWriterSettings();
//        xmlwriterSettings.Indent = true;
//        using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
//        {
//            using (IsolatedStorageFileStream isoStream = iso.OpenFile("DataCollection.xml", FileMode.Create))
//            {
//                DataContractSerializer serializer = new DataContractSerializer(typeof(Data));
//                using (XmlWriter xmlWriter = XmlWriter.Create(isoStream, xmlwriterSettings))
//                {

//                }
//            }
//        }

//    }
//    public override void Save()
//    {
//        throw new NotImplementedException();
//    }