using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.DataService
{
    public abstract class DataManagerBase
    {
        private List<Album> albums;
        private UserInfo userInfo;

        public DataManagerBase()
        {
            albums = new List<Album>();
        }

        public abstract void Load();

        public abstract void Save();
                
        public void AddPhoto(string albumName, params Photo[] photos)
        {
            albums.First((album)=>{ return album.Name==albumName;}).PhotoList.AddRange(photos);
        }

        public Album GetAlbum(string albumName)
        {
            return albums.First((album) => { return album.Name == albumName; });
        }

        public UserInfo GetUserInfo()
        {
            return userInfo;
        }
    }
}
