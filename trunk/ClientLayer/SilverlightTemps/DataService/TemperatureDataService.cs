///////////////////////////////////////////////////////////
//  TemperatureDataService.cs
//  Implementation of the Class TemperatureDataService
//  Generated by Enterprise Architect
//  Created on:      28-Feb-2009 7:29:55 PM
//  Original author: Gary
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace SilverlightTemps.DataService {
    
    public delegate void TemperatureDataEventHandler(object sender, TemperatureDataEventArgs e);

	public class TemperatureDataService {

		/// 
		/// <param name="stationId"></param>
		/// <param name="days"></param>
        public virtual void GetRecentTemperaturesAsync(string stationId, int days)
        {
        }

		/// 
		/// <param name="tempDays"></param>
        protected virtual void OnGetRecentTemperaturesComplete(List<TemperatureDay> tempDays)
        {
            this.AugmentTemperatureDays(tempDays);
            if (this.GetRecentTemperaturesComplete != null)
                this.GetRecentTemperaturesComplete(this, new TemperatureDataEventArgs(tempDays));
        }
        protected virtual void AugmentTemperatureDays(List<TemperatureDay> tempDays)
        {
            tempDays.Sort(delegate(TemperatureDay a, TemperatureDay b)
            {
                return a.SubjectDate.CompareTo(b.SubjectDate);
            });
        }

        public event TemperatureDataEventHandler GetRecentTemperaturesComplete;


	}//end TemperatureDataService

}//end namespace DataService