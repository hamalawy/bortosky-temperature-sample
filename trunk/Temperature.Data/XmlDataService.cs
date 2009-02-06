///////////////////////////////////////////////////////////
//  XmlDataService.cs
//  Implementation of the Class XmlDataService
//  Generated by Enterprise Architect
//  Created on:      05-Feb-2009 9:11:42 AM
//  Original author: Gary
///////////////////////////////////////////////////////////




using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using Bortosky.Samples.Temperature.Data;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Linq;
namespace Bortosky.Samples.Temperature.Data {
	public class XmlDataService : IDataService {

		private XDocument temperatureData;

		/// <summary>
		/// Initialize and open the temeratureData xml document from the executing assembly
		/// folder
		/// </summary>
        public XmlDataService()
        {
            this.temperatureData = XDocument.Load(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "temps.xml"));
        }

		/// 
		/// <param name="date"></param>
		/// <param name="days"></param>
        public List<DateTemperatureRange> GetTemperaturesByDate(string stationId, DateTime date, int days)
        {
            var dtr = new List<DateTemperatureRange>();
            var query =
                from item in this.temperatureData.Root.Descendants("DBROW")
                where (item.Element("STATION_ID").Value.CompareTo(stationId) == 0 && item.Element("YEARMODA").Value.CompareTo(date.ToString("yyyyMMdd")) >= 0) && (item.Element("YEARMODA").Value.CompareTo(date.AddDays(days).ToString("yyyyMMdd")) < 0)
                orderby (string)item.Element("YEARMODA")
                select new DateTemperatureRange(
                    new TemperatureRange(float.Parse(item.Element("MINTEMP").Value), float.Parse(item.Element("MAXTEMP").Value)),
                    new DateTime(int.Parse(item.Element("YEARMODA").Value.Substring(0, 4)),
                        int.Parse(item.Element("YEARMODA").Value.Substring(4, 2)),
                        int.Parse(item.Element("YEARMODA").Value.Substring(6, 2))
                        )
                    );
            dtr.AddRange(query);
            return dtr;
        }

		/// 
		/// <param name="year"></param>
		/// <param name="month"></param>
        public List<DateTemperatureRange> GetTemperaturesByMonth(string stationId, int year, int month)
        {
            DateTime f = new DateTime(year, month, 1);
            return this.GetTemperaturesByDate(stationId, f, f.AddMonths(1).AddDays(-1).Day);
        }

	}//end XmlDataService

}//end namespace Data