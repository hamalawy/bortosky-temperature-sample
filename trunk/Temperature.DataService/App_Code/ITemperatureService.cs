﻿///////////////////////////////////////////////////////////
//  ITemperatureService.cs
//  Implementation of the Interface ITemperatureService
//  Generated by Enterprise Architect
//  Created on:      05-Feb-2009 3:21:40 PM
//  Original author: Gary
///////////////////////////////////////////////////////////




using System.Collections.Generic;
using System.ServiceModel;
namespace Bortosky.Samples.Temperature.DataService
{
    [ServiceContract]
    public interface ITemperatureService
    {

        /// <summary>
        /// Uses primitives for date parts instead of System.DateTime for platform
        /// independence
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="days">The days after the start date to return.  The date of the
        /// last DateTemperatureRange returned will be <= the start date plus this value.
        /// </param>
        [OperationContract]
        List<DateTemperatures> GetTemperaturesByDate(int year, int month, int day, int days);

        /// <summary>
        /// Returns a DateTemperatureRange for each day of the requested month
        /// </summary>
        /// <param name="year">The year part of the month whose temeprature ranges are
        /// requested</param>
        /// <param name="month">The month in the given year whose temperature ranges are
        /// requested</param>

        [OperationContract]
        List<DateTemperatures> GetTemperaturesByMonth(int year, int month);
    }//end ITemperatureService

}//end namespace DataService