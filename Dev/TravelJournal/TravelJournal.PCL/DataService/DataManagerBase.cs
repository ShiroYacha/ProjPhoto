using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.BusinessLogic;

namespace TravelJournal.PCL.DataService
{
    public abstract class DataManagerBase
    {
        private List<Album> albumsCollection;
        private UserInfo userInfo;
        

    

        public List<Album> GetAlbumsCollection()
        {
            return this.albumsCollection;
        }
        public void SetAlbums(List<Album> albumsCollection)
        {
            this.albumsCollection = albumsCollection;
        }
        public UserInfo GetUserInfo()
        {
            return this.userInfo;
        }
        public void SetUserInfo(UserInfo userInfo)
        {
            this.userInfo = userInfo;
        }
      

        public abstract void Load();

        public abstract void Save();
                
        public void AddPhoto(string albumName, params Photo[] photos)
        {
            albumsCollection.First((album)=>{ return album.AlbumName==albumName;}).PhotoList.AddRange(photos);
        }

        public Album GetAlbum(string albumName)
        {
            return albumsCollection.First((album) => { return album.AlbumName == albumName; });
        }

      
    }
}
