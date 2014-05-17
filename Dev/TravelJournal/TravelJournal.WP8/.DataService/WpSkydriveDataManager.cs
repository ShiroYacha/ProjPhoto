using Microsoft.Live;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TravelJournal.PCL.BusinessLogic;
using TravelJournal.PCL.DataService;
using Windows.Storage;

namespace TravelJournal.WP8.DataService
{
    public class WpSkydriveDataManager : DataManagerBase
    {
        private LiveConnectClient client;
        private string folderId;

        private static string folderName = "traveljournal";
        private static string fileName = "default.dat";
        private static string targetFileName = string.Format("/shared/transfers/{0}/{1}", folderName, fileName);
        private static Uri targetIsoUri = new Uri(targetFileName, UriKind.Relative);
        
        private DataContractSerializer serializer = new DataContractSerializer(typeof(Data));

        private IsolatedStorageFile isoFile;
        IsolatedStorageFile IsoFile
        {
            get
            {
                if (isoFile == null)
                    isoFile = IsolatedStorageFile.GetUserStoreForApplication();
                return isoFile;
            }
        }

        public async Task Initialize()
        {
            await Login();
            folderId = await GetDirectoryAsync(folderName, "me/skydrive");
        }

        public async override void Load()
        {
            await Initialize();

            LiveOperationResult liveOperationResult = await client.GetAsync(folderId + "/files");
            dynamic result = liveOperationResult.Result.Values.First();
            Data = null;
            foreach (IDictionary<string, object> content in result)
            {
                string fileId = (string)content["id"];
                LiveOperationResult operationResult = await client.BackgroundDownloadAsync(fileId + "/Content?type=notebook", targetIsoUri);
                using (var sourceStream =
                        IsoFile.OpenFile(targetFileName, FileMode.Open))
                {
                    Data = (Data)serializer.ReadObject(sourceStream);
                }
                break;
            }
            if (Data == null)
                Data = new Data()
                {
                    State = new OriginalState(),
                    UserInfo = new UserInfo("test", new GpsPosition("France", "Metz", null)),
                    AlbumCompleted = false,
                    AlbumsCollection = new List<Album>(),
                    TouristCity = new List<string>(),
                    TourRoutePoints = new List<GpsPosition>()
                };
        }

        public async override void Save()
        {

            if (!IsoFile.DirectoryExists("/shared/transfers/traveljournal"))
                IsoFile.CreateDirectory("/shared/transfers/traveljournal");
            try
            {
                using (var targetFile = IsoFile.CreateFile(targetFileName))
                {
                    serializer.WriteObject(targetFile, Data);
                }
            }
            catch (Exception e)
            {
                IsoFile.DeleteFile(targetFileName);
            }
            await client.BackgroundUploadAsync(folderId, targetIsoUri, OverwriteOption.Overwrite);
        }

        public async Task SaveAsync()
        {

            if (!IsoFile.DirectoryExists("/shared/transfers/traveljournal"))
                IsoFile.CreateDirectory("/shared/transfers/traveljournal");
            try
            {
                using (var targetFile = IsoFile.CreateFile(targetFileName))
                {
                    serializer.WriteObject(targetFile, Data);
                }
            }
            catch (Exception e)
            {
                IsoFile.DeleteFile(targetFileName);
            }
            await client.BackgroundUploadAsync(folderId, targetIsoUri, OverwriteOption.Overwrite);
        }

        public async Task LoadBackgroundAsync()
        {
            LiveOperationResult liveOperationResult = await client.GetAsync(folderId + "/files");
            dynamic result = liveOperationResult.Result.Values.First();
            Data = null;
            foreach (IDictionary<string, object> content in result)
            {
                string fileId = (string)content["id"];
                LiveOperationResult operationResult = await client.BackgroundDownloadAsync(fileId + "/content", targetIsoUri);
                using (var sourceStream =
                        IsoFile.OpenFile(targetFileName, FileMode.Open))
                {
                    Data = (Data)serializer.ReadObject(sourceStream);
                    break;
                }
            }
            if (Data == null)
                Data = new Data()
                {
                    State = new OriginalState(),
                    UserInfo = new UserInfo("test", new GpsPosition("France", "Metz", null)),
                    AlbumCompleted = false,
                    AlbumsCollection = new List<Album>(),
                    TouristCity = new List<string>(),
                    TourRoutePoints = new List<GpsPosition>()
                };
        }

        public async Task LoadAsync()
        {
            LiveOperationResult liveOperationResult = await client.GetAsync(folderId + "/files");
            dynamic result = liveOperationResult.Result.Values.First();
            Data = null;
            foreach (IDictionary<string, object> content in result)
            {
                string fileId = (string)content["id"];
                LiveDownloadOperationResult operationResult = await client.DownloadAsync(fileId + "/content");
                Data = (Data)serializer.ReadObject(operationResult.Stream);
            }
            if (Data == null)
                Data = new Data()
                {
                    State = new OriginalState(),
                    UserInfo = new UserInfo("test", new GpsPosition("France", "Metz", null)),
                    AlbumCompleted = false,
                    AlbumsCollection = new List<Album>(),
                    TouristCity = new List<string>(),
                    TourRoutePoints = new List<GpsPosition>()
                };
        }


        public async Task Login()
        {
            var auth = new LiveAuthClient("000000004C11AF34");
            var result = await auth.InitializeAsync(new[] { "wl.basic", "wl.signin", "wl.skydrive_update" });

            // If you're not connected yet, that means you'll have to log in.
            if (result.Status != LiveConnectSessionStatus.Connected)
            {

                // This will automatically show the login screen
                result = await auth.LoginAsync(new[] { "wl.basic", "wl.signin", "wl.skydrive_update" });
            }

            if (result.Status == LiveConnectSessionStatus.Connected)
            {
                client = new LiveConnectClient(result.Session);
            }
        }

        public async Task<string> GetDirectoryAsync(string folderName, string parentFolder)
        {
            string folderId = null;

            // Retrieves all the directories.
            var queryFolder = parentFolder + "/files?filter=folders,albums";
            var opResult = await client.GetAsync(queryFolder);
            dynamic result = opResult.Result;

            foreach (dynamic folder in result.data)
            {
                // Checks if current folder has the passed name.
                if (folder.name.ToLowerInvariant() == folderName.ToLowerInvariant())
                {
                    folderId = folder.id;
                    break;
                }
            }

            if (folderId == null)
            {
                // Directory hasn't been found, so creates it using the PostAsync method.
                var folderData = new Dictionary<string, object>();
                folderData.Add("name", folderName);
                opResult = await client.PostAsync(parentFolder, folderData);
                result = opResult.Result;

                // Retrieves the id of the created folder.
                folderId = result.id;
            }

            return folderId;
        }

    }
}
