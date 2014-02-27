using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.DataService
{
    abstract class DataManagerBase
    {
        private Album album;
        private User user;

        public DataManagerBase()
        {
            album = new Album();
            user = new User();
        }
        public DataManagerBase(Album album, User user)
        {
            this.album = album;
            this.user = user;
        }
        public DataManagerBase Load()
        {
            return this;
        }

        public void Save()
        {

        }
        public Album AddPhoto(Photo aPhoto)
        {
            album.PhotoList.Add(aPhoto);
            return album;
        }
        public Album AddPhoto(IEnumerable<Photo> aPhotoList)
        {
            album.PhotoList.AddRange(aPhotoList);
            return album;
        }
        public Album GetAlbum()
        {
            return this.album;
        }
        public User GetUserInfo()
        {
            return this.user;
        }
    }
}
