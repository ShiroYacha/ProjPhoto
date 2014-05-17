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
using TravelJournal.PCL.BusinessLogic;


namespace TravelJournal.WP8.DataService
{
    public class WpIsoDataManager : DataManagerBase
    {
        DataSaver<Data> dataSaver =
              new DataSaver<Data>();
        
        public override void Load()
        {
            Data = dataSaver.LoadMyData("default.dat"); 
            // Assign first
            if(Data==null)
            {
                dataCollection = new Data()
                {
                    State=new OriginalState(),
                    UserInfo=new UserInfo("test",new GpsPosition("France","Metz",null)),
                    AlbumCompleted=false,
                    AlbumsCollection=new List<Album>(),
                    TouristCity=new List<string>(),
                    TourRoutePoints = new List<GpsPosition>()
                };
            }
        }
        public override void Save()
        {
            dataSaver.SaveMyData(Data, "default.dat");
        }

    }

    public class DataSaver<MyDataType>
    {
        private const string folderName = "traveljournal";
        private DataContractSerializer _mySerializer;
        private IsolatedStorageFile _isoFile;
        IsolatedStorageFile IsoFile
        {
            get
            {
                if (_isoFile == null)
                    _isoFile = IsolatedStorageFile.GetUserStoreForApplication();
                return _isoFile;
            }
        }

        public DataSaver()
        {
            _mySerializer = new DataContractSerializer(typeof(MyDataType));
        }

        public void SaveMyData(MyDataType sourceData, String fileName)
        {
            string targetFileName = string.Format("/shared/transfers/{0}/{1}", folderName, fileName);

            if (!IsoFile.DirectoryExists("/shared/transfers/traveljournal"))
                IsoFile.CreateDirectory("/shared/transfers/traveljournal");
            try
            {
                using (var targetFile = IsoFile.CreateFile(targetFileName))
                {
                    _mySerializer.WriteObject(targetFile, sourceData);
                }
            }
            catch (Exception e)
            {
                IsoFile.DeleteFile(targetFileName);
            }


        }

        public MyDataType LoadMyData(string sourceName)
        {
            MyDataType retVal = default(MyDataType);
            string targetFileName = string.Format("/shared/transfers/{0}/{1}", folderName, sourceName);

            if (IsoFile.FileExists(targetFileName))
                using (var sourceStream =
                        IsoFile.OpenFile(targetFileName, FileMode.Open))
                {
                    retVal = (MyDataType)_mySerializer.ReadObject(sourceStream);
                }
            return retVal;
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