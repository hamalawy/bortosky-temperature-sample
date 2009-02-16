///////////////////////////////////////////////////////////
//  ITemperatureSerializer.cs
//  Implementation of the Interface ITemperatureSerializer
//  Generated by Enterprise Architect
//  Created on:      13-Feb-2009 3:06:17 PM
//  Original author: Gary
///////////////////////////////////////////////////////////




using System.IO;
namespace Bortosky.Samples.Temperature.Client.DataLayer {
	public interface ITemperatureSerializer {

		/// 
		/// <param name="stationId"></param>
		/// <param name="year"></param>
		/// <param name="month"></param>
		/// <param name="day"></param>
		/// <param name="days"></param>
		/// <param name="stream"></param>
		void SerializeTemperatureData(string stationId, int year, int month, int day, int days, Stream stream);

		/// 
		/// <param name="stationId"></param>
		/// <param name="days"></param>
		/// <param name="stream"></param>
		void SerializeRecentTemperatureData(string stationId, int days, Stream stream);
	}//end ITemperatureSerializer

}//end namespace DataLayer