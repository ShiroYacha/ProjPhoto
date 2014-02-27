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
        private List<Photo> photoList;

        public string Name
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

        public DateTime GetTimeTag()
        {
            
            foreach (Photo p in PhotoList)
            {
                if (p.Point.TimeStamp > timeTag)
                {
                    timeTag = p.Point.TimeStamp;
                }
            }
            return timeTag;
        }


    }

}
