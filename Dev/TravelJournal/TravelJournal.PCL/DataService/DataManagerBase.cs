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
        private State state;

        public List<Album> AlbumsCollection
        {
            get { return albumsCollection; }
            set { albumsCollection = value; }
        }
     
        public UserInfo UserInfo
        {
            get { return this.userInfo;}
            set {userInfo = value;}
        }
        
        public State State
        {
            get { return this.state; }
            set { state = value; }
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
