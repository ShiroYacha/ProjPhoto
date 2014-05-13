using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.PCL.DataService;

namespace TravelJournal.WP8.UI.Test
{
    public class DesignTimeDataManager:DataManagerBase
    {
        public override void Load()
        {
            Data = new Data();
            List<Album> albumList = new List<Album>();
            albumList.Add(new Album()
                {
                    Name="Test album 1",
                    TimeTag=DateTime.Parse("7:00:00 2012/9/12"),
                    PhotoList = new List<Photo>()
                    {

                    }
                });
            Data.AlbumsCollection = albumList;
        }

        public override void Save()
        {
            
        }
    }
}
