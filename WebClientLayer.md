# Introduction #
The web client layer for the temperature sample uses Google Visualization APIs to display the most recent temperature information in an annotated time line.
## Data Layer ##
To provide maximum flexibility for the client, the Web Service providing the temperature data from another domain is isolated in its own Data Layer.
The Data layer consumes the Web Service and returns a System.Data.DataTable, which is suitable for use by my separate Google Visualization library.

![http://www.bortosky.com/samples/temperature/img/ClientDataLayer.gif](http://www.bortosky.com/samples/temperature/img/ClientDataLayer.gif)

### ITemperatureSerializer ###
The `ITemperatureSerializer` interface specifies the operation used by the client layer, namely to serialize the temperature data onto a stream.
The reference implementation, by `GoogleVisualizationTemperatureSerializer`, uses [my own public, free, open-source library](http://code.google.com/p/bortosky-google-visualization/) for producing Google Visualization data from .NET types.
## Web Layer ##
The actual exposed Web layer is composed of
  * a simple call to the data layer to retrieve the Google-formatted data,
  * the rendering of the Google Annotated Time Line visualization using JavaScript.

Please see http://www.bortosky.com/samples/temperature/googletimeline.aspx for the completed demonstration.