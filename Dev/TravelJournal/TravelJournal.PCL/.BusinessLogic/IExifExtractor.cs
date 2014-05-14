
namespace TravelJournal.PCL.BusinessLogic
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using TravelJournal.PCL.DataService;

	public interface IExifExtractor 
	{
        GpsPoint ExtractGeoCoordinate(Photo photo);
	}
}

