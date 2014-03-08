using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.DataService;

namespace TravelJournal.PCL.BusinessLogic
{
    class PhotoOrganizer:IPhotoOrganizer
    {
        public PhotoOrganizer() { }
        public void OrganizePhoto(Photo photo, Album album)
        {
            album.PhotoList.Add(photo);
        }
        
    }
}
