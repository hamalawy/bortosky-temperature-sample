using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Bortosky.Samples.Temperature.DataService.DataLayer;

namespace Bortosky.Samples.Temperature.DataService.ServiceLayer
{

    [WebService(Namespace = "http://bortosky.org/temperature")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TemperatureService : System.Web.Services.WebService
    {
        public TemperatureService()
        {
        }

        [WebMethod]
        public TemperatureResponse GetTemperaturesByDay(string StationID, int Year, int Month, int Day, int Days)
        {
            return new XmlTemperatureReader().GetTemperaturesByDate(StationID, Year, Month, Day, Days);
        }

        [WebMethod]
        public TemperatureResponse GetTemperaturesByMonth(string StationID, int Year, int Month)
        {
            return this.GetTemperaturesByDay(StationID, Year, Month, 1, new DateTime(Year, Month, 1).AddMonths(1).AddDays(-1).Day);
        }

    }
}
