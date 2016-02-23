# Overview #
The Temperature Service Layer is composed of two packages.
  * A Data Layer interface and implementation using Linq to XML
  * A Web layer exposing the temperature data from the Data Layer on a different domain, through SOAP
## Data Layer ##
The National Climatic Data Service provides a [web interface](http://cdo.ncdc.noaa.gov/CDO/wmores40.jsp?page=http://www7.ncdc.noaa.gov/CDO/cdoselect.cmd?datasetabbv=GSOD%26countryabbv=%26georegionabbv=) to download climate data in various formats.
An [XML file](NCDCXmlFormat.md) of daily high and low temperatures for Lambert-St. Louis International Airport for an arbitrary period provides the data for the sample application.
Using the **contract-first** pattern, an XSD schema was used to generate the types used by the Service Layer and the types were generated using the **xsd.exe** tool.
Contract-first helps ensure interopability with other non .NET clients, for example, an [ISO 8601](http://www.w3.org/TR/NOTE-datetime) format (as a standard xs:string) is used for the temperature date instead of a System.DateTime.
Note that the System.DateTime is serialized in a proper interopable manner by the ASP.NET web service framework but the ISO format was used for demonstration purposes.
**Linq to XML** and a **generic collection** are used to read the requested temperatures from the XML file and return a composite response object to the calling program, in this case, the Service Layer.

![http://www.bortosky.com/samples/temperature/img/ServiceDataLayer.gif](http://www.bortosky.com/samples/temperature/img/ServiceDataLayer.gif)

The NCDC seems to be returning temperatures of 9999.9 in certain circumstances, probably because of unreported data.
For purposes of demonstration, these temperatures are adjusted to the prior day's values.
This adjustment is done at this lowest level Data Layer so downstream clients won't have to deal with the bad data.
#### ITemperatureReader ####
To keep the Service Layer lean and clean, `ITemperatureReader` specifies a general-purpose, low-level `GetTemperaturesByDate` method.
Callers, such as this reference application, can compose methods over this one, such as `GetTemperaturesByMonth`, which computes appropriate argument values for `GetTemperaturesByDate`.
Another method specified by the interface to one to retrieve the limits of the data available, i.e., the first date for which a temperature range is available.
The XMLTemperatureReader uses the **lambda expression** predicate capabilities of the **Linq to XML** framework types to provide a concise and fast implementation for this method.
Of course the `XMLTemperatureReader` is only a reference implementation of the `ITemperatureReader` interface. Other implementations might be a `SqlServerTemperatureReader` or `OracleTemperatureReader`.
## Web Layer ##
The Web Layer simply provides a **web service** front-end to the underlying data layer described above.
The service is available at http://sns.tzo.com/bortoskyservices/TemperatureService.asmx.
As mentioned above, the service also exposes a second method, `GetTemperaturesByMonth` which simply computes appropriate argument values for the TemperatureReader's `GetTemperaturesByDate` method.
The XSD schema specifying the composite Response type is available at http://sns.tzo.com/bortoskyservices/TemperatureContract.xsd.
The response was wrapped in a composite object for maximum contract flexibility. New items can be added to the response requiring only a recompile of client code, not a recoding.
Note that the graphical schema designer was removed from Visual Studio 2008 for some reason.
Many other schema editors are available but this simple one was composed manually in the VS 2008 text-based editor.