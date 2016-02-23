The working sample is available at http://www.bortosky.com/samples/temperature/silverlighttemps.htm.

# Features #
The Silverlight package of this sample project has these features

## Animation ##
The sample implements Storyboard animations both in the KeyFrame flavor which is recorded in Expression Blend, and also with simple DoubleAnimation objects which are code-based.

## Cross-domain Data Service ##
The sample retrieves its data from the same service provider domain that the Google Visualization sample uses. For this version, the Silverlight version uses a mock object as cross-domain service access is problematic.

## Custom User Control ##
The gauge showing the range of temperatures for the selected day is a separate, loosely coupled modular control

## Silverlight Styles and Resources ##
The red and green temperature colors are separate resources as are the other visual display styles. Silverlight uses a resource model to separate content from presentation and this sample abides by that separation.

## Value Converters ##
Silverlight uses ValueConverter objects to get data to and from the user interface with data binding. The sample demonstrates use of a couple of them.


# SilverlightTemps #
The SilverlightTemps package is the main application consisting of a DataService package and a ValueConverters package.


## App ##
Resources and styles for the application.


## Page ##
The main UserControl for the application

### Attributes ###
|TempDays|Private|List`<TemperatureDay>`|The collection of TemperatureDay objects for display|
|:-------|:------|:---------------------|:---------------------------------------------------|
|selectedDayIndex|Private|int                   |The index of the currently selected TemperatureDay  |
|selectedDay|Private|TemperatureDay        |Private backing member for the SelectedDayIndex property|

### Methods ###
|Page|Public|| |
|:---|:-----|:|:|
|PrevBtn\_Click|Private|void|Decrements the selected day|
|NextBtn\_Click|Private|void|Increments the selected day|
|Page\_Loaded|Private|void|Handler for the Loaded event which retrieves the TemperatureDays from the data layer|
|ds\_GetRecentTemperaturesComplete|Private|void| |
|SelectedDayIndex|Private|int|The index of the currently selected TemperatureDay. The property setter changes the user interface and begins animations.|


## RangeGauge ##
A composite UserControl which is used by the the main Page class. The range supported by the guage is hard-coded for sample simplicity but could easily be configurable.

### Attributes ###
|GaugeMin|Private|double|Hard-code minimum value for the gauge|
|:-------|:------|:-----|:------------------------------------|
|GaugeMax|Private|double|Hard-coded maximum value for the gauge|
|GaugeWidthProperty|Public |DependencyProperty|                                     |
|subject |Private|TemperatureDay|                                     |

### Methods ###
|RangeGauge|Public|Constructor| |
|:---------|:-----|:----------|:|
|GaugeWidth|Public|double     |A dependency property allowing the client XAML to set the gauge's width for optimal presentation.|
|SubjectTemperatureDay|Public|TemperatureDay|The interface of the control to client applications. The property setter handles updating of the controls values to display the TemperatureDay's temperature range.|
|RedrawThumb|Private|void       |Draws the TemperatureDay's range modifying the properties of the rectangle component of the UserControl after computing the appropriate values.|


## TemperatureDay ##
A flattened object suitable for Silverlight data binding. These types are created from the values recieved from the data service.

### Methods ###
|SubjectDate|Public|DateTime|The day whose temperatures are stored|
|:----------|:-----|:-------|:------------------------------------|
|MaxTemperature|Public|float   |Maximum temperature for the day      |
|MinTemperature|Public|float   |Minimum temperature for the day      |


# DataService #
The DataService package contains the data layer types for the SilverlightTemps application. Note the use of a mock temperature service which is a specialization of the TemperatureDataService abstract class. The mock service keeps us from hitting the real web service during development and can easilly be swapped out with the SoapTemperatureDataService for production. Both the mock and SOAP versions specialize the abstract class. Since Silverlight's service proxy uses Async methods exclusively, the sample's wrapper service also implements a asynchronous pattern with a delegate and event, plus an EventArgs implementation to return the retrieved temperature data to the calling application.


## MockTemperatureDataService ##
Returns a set of hard-coded data

### Methods ###
|GetRecentTemperaturesAsync|Public|void|See base class|
|:-------------------------|:-----|:---|:-------------|


## SoapTemperatureDataService ##
Returns data from a SOAP service proxy.

### Methods ###
|GetRecentTemperaturesAsync|Public|void|See base class|
|:-------------------------|:-----|:---|:-------------|


## TemperatureDataEventArgs ##
An EventArgs implementation to return the retrieved data to the calling application.

### Attributes ###
|TemperatureDays|Public|List`<TemperatureDay>`|The generic list of TemperatureDays returned by the data layer and suitable for consumption by a calling application.|
|:--------------|:-----|:---------------------|:--------------------------------------------------------------------------------------------------------------------|

### Methods ###
|TemperatureDataEventArgs|Public|A generic collection of the returned data| |
|:-----------------------|:-----|:----------------------------------------|:|


## TemperatureDataService ##
An abstract class specifying the asynch methods to retrieve TemperatureDay objects in a Generic List.

### Methods ###
|TemperatureCompleteEventHandler|Public|void|Client applications should provide a delegate for this handler to consume the returned data. See the source code for an example.|
|:------------------------------|:-----|:---|:-------------------------------------------------------------------------------------------------------------------------------|
|GetRecentTemperaturesAsync     |Public|void|Begins the collection of data. Client applications should provide a delegate to receive the data when it is ready.              |
|OnGetRecentTemperaturesComplete|Protected|void|A protected virtual method used to raise the event and provide a hook to overriders.                                            |
|GetRecentTemperaturesComplete  |Public|TemperatureDataEventHandler|Event raised when the temperature data is ready for consumption by the calling application                                      |


# ValueConverters #
ValueConverters are Silverlight's way of getting values back and forth from the User Interface. The sample uses a couple of them.


## LongDateConverter ##
Spells out the whole date for use on the user interface

### Methods ###
|Convert|Public|Object||
|:------|:-----|:-----|:|
|ConvertBack|Public|Object||


## TemperatureTextConverter ##
Formats the floating point temperature for display including the degree symbol.

### Methods ###
|Convert|Public|Object||
|:------|:-----|:-----|:|
|ConvertBack|Public|Object||