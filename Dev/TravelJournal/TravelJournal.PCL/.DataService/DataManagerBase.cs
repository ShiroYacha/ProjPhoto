using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.BusinessLogic;

namespace TravelJournal.PCL.DataService
{
    public abstract class DataManagerBase
    {
        private const string NAME_CURRENT_ALBUM = "DEFAULT_CURRENT_ALBUM";
        protected Data dataCollection;

        public Data Data
        {
            get { return dataCollection; }
            set { dataCollection = value; }
        }

        public abstract void Load();

        public abstract void Save();
                
        public void AddPhoto(string albumName, params Photo[] photos)
        {
            dataCollection.AlbumsCollection.First((album)=>{ return album.Name==albumName;}).PhotoList.AddRange(photos);
        }

        public Album GetAlbum(string albumName)
        {
            if (dataCollection.AlbumsCollection.Count == 0) return null;
            return dataCollection.AlbumsCollection.First((album) => { return album.Name == albumName; });
        }

        public Album GetCurrentAlbum()
        {
            return GetAlbum(NAME_CURRENT_ALBUM) ?? CreateCurrentAlbum();
        }

        public void RenameCurrentAlbum(string newName)
        {
            GetAlbum(NAME_CURRENT_ALBUM).Name = newName;
        }

        private Album CreateCurrentAlbum()
        {
            Album currentAlbum = new Album() { Name = NAME_CURRENT_ALBUM,TimeTag=DateTime.Now };
            dataCollection.AlbumsCollection.Add(currentAlbum);
            return currentAlbum;
        }
    }
}
