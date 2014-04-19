﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.DataService;

namespace TravelJournal.PCL.BusinessLogic
{
    public class PhotoOrganizer:IPhotoOrganizer
    {
        public void OrganizePhoto(Photo photo, Album album)
        {
            album.PhotoList.Add(photo);
            album.TimeTag = photo.Position.GpsPoint.Timestamp;
        }
        
    }
}
