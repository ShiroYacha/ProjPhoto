﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace TravelJournal.PCL.BusinessLogic
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public interface IExifExtractor 
	{
		IBackgroudProcessor IBackgroudProcessor { get;set; }

		GeoCoodinate ExtractGeoCoordinate();

	}
}

