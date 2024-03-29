///////////////////////////////////////////////////////////
//  ITemperatureReader.cs
//  Implementation of the Interface ITemperatureReader
//  Generated by Enterprise Architect
//  Created on:      09-Feb-2009 4:45:30 PM
//  Original author: Gary
///////////////////////////////////////////////////////////



using System.Collections.Generic;
using Bortosky.Samples.Temperature.DataService.DataLayer;
namespace Bortosky.Samples.Temperature.DataService.DataLayer {
	/// <summary>
	/// Specifies operations for the Data Layer. The first implementation of which will
	/// be to retrieve the data from an XML file. The operations use primitive data
	/// types for cross-platform purposes.
	/// </summary>
	public interface ITemperatureReader {

		/// 
		/// <param name="stationId">The station identifer from the National Climatic Data
		/// Center</param>
		/// <param name="year"></param>
		/// <param name="month"></param>
		/// <param name="day"></param>
		/// <param name="days">The days to return, note you may receive less than this
		/// number if data is missing from the source. The last date returned will be this
		/// many days past the specified start date</param>
		TemperatureResponse GetTemperaturesByDate(string stationId, int year, int month, int day, int days);

		/// 
		/// <param name="string"></param>
		AvailableDatesResponse GetAvailableDates(string stationId);
	}//end ITemperatureReader

}//end namespace DataLayer