
namespace TravelJournal.PCL.BusinessLogic
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using TravelJournal.PCL.DataService;

	public interface IPhotoOrganizer 
	{
        void OrganizePhoto(Photo photo, Album album);
	}
}

