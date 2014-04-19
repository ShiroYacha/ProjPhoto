using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace TravelJournal.PCL.DataService
{
    [DataContract]
    public class Album
    {
        DateTime timeTag;
        private string albumName;
        private List<Photo> photoList=new List<Photo>();

        [DataMember]
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

        [DataMember]
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

        [DataMember]
        public DateTime TimeTag
        {
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
