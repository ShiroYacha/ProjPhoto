﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace TravelJournal.PCL.DataService
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public interface IAlbum 
	{
		double longitude { get;set; }

		double latitude { get;set; }

		DataTime time { get;set; }

		IDataManager IDataManager { get;set; }

	}
}

