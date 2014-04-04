using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TravelJournal.PCL.DataService
{
    public class Album
    {
        DateTime timeTag;
        private string albumName;
        private List<Photo> photoList=new List<Photo>();

        public string AlbumName
        {
            get
            {
                return albumName;
            }
            set
            {
                albumName = value;
            }
        }

        public List<Photo> PhotoList
        {
            get
            {
                return photoList;
            }
            set
            {
                photoList = value;
            }
        }

        public Album() { }
        public Album( List<Photo> photoList){
            this.albumName = "NoNameAlbum";
            this.photoList = photoList;
      }
        public Album(string albumName, List<Photo> photoList)
        {
            this.albumName = albumName;
            this.photoList = photoList;
        }

        public DateTime TimeTag
        {
            
            //foreach (Photo p in PhotoList)
            //{
            //    if (p.Point.Timestamp > timeTag)
            //    {
            //        timeTag = p.Point.Timestamp;
            //    }
            //}
            get
            {
                return timeTag;
            }
            set
            {
                timeTag = value;
            }
        }


    }

}
