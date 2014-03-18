using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;

namespace TravelJournal.WP8.DataService
{
    public class DataSaver<MyDataType>
    {
        private const string TargetFolderName = "MyFolderName";
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

        public void SaveMyData(MyDataType sourceData, String targetFileName)
        {
            string TargetFileName = String.Format("{0}/{1}.dat",
                                           TargetFolderName, targetFileName);
            if (!IsoFile.DirectoryExists(TargetFolderName))
                IsoFile.CreateDirectory(TargetFolderName);
            try
            {
                using (var targetFile = IsoFile.CreateFile(TargetFileName))
                {
                    _mySerializer.WriteObject(targetFile, sourceData);
                }
            }
            catch (Exception e)
            {
                IsoFile.DeleteFile(TargetFileName);
            }


        }

        public MyDataType LoadMyData(string sourceName)
        {
            MyDataType retVal = default(MyDataType);
            string TargetFileName = String.Format("{0}/{1}.dat",
                                                  TargetFolderName, sourceName);
            if (IsoFile.FileExists(TargetFileName))
                using (var sourceStream =
                        IsoFile.OpenFile(TargetFileName, FileMode.Open))
                {
                    retVal = (MyDataType)_mySerializer.ReadObject(sourceStream);
                }
            return retVal;
        }
    }
}
