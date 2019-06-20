## About
In cooperation with [StreamStats](https://streamstats.usgs.gov/), the runoff modeling services were developed using RESTful principles in order to assist engineers and watershed managers by calculating peak discharge for small watersheds. This API is intended to document the available service endpoints and provide limited example usage to assist developers in building outside programs that leverage the same data sources in an effort to minimize duplicative efforts across the USGS and other agencies.

## Status
The Runoff Modeling Services provides two simple hydrologic models that compute peak discharge for small watersheds, the NRCS Runoff Curve Number method (TR55) and the Rational Method.

## Getting Started
The URL and sample of each resource can be obtained by accessing one of the following resources located on the sidebar (or selecting the menu button located on the bottom of the screen, if viewing on a mobile device). The runoff modeling services perform procedures to compile and create simple responses with hypermedia enabled links to related resources. The responses are intended to be directly consumed by custom client applications and used to more fully decouple the client-service relationship by providing directional hypermedia links within the resource response objects.

## Using the API
The URL and an example response can be obtained by accessing one of the following resources and uri endpoint located on the sidebar (or selecting the menu button located on the bottom of the screen, if viewing on a mobile device). 

### TR55
The TR55 method is a simple technique for estimating peak runoff from a small watershed. It was developed by the Natural Resources Conservation Service (NRCS), 1986 for small drainage basins that are being urbanized.

The method begins with a rainfall amount uniformly imposed on the watershed over a specified time distribution. Mass rainfall is converted to mass runoff by using a runoff curve number (RCN). RCN is based on soils, plant cover, amount of impervious areas, interception, and surface storage. Runoff is then transformed into a hydrograph by using unit hydrograph theory and routing procedures that depend on runoff travel time through segments of the watershed (USDA NRCS CED, TR-55, 1986). The Runoff Modeling Services API collects time distributions from NOAA Atlas temporal distribution data to determine runoff travel time. TR55 is expressed by the equation:

> Q = (P-Iₐ)² / ((P-Iₐ)+S)

> where

> Q = runoff, in inches<br />
> P = rainfall, in inches<br />
> S = potential maximum retention after runoff begins, in inches, and<br />
> Iₐ = initial abstraction, in inches

>> *USDA Natural Resources Conservation Service (NRCS), June 1986, Technical Release 55: Urban Hydrology for Small Watersheds, 164 p. > [Also available at https://www.nrcs.usda.gov/Internet/FSE_DOCUMENTS/stelprdb1044171.pdf.]*
	 
### Rational Method
The Rational Method is another simple technique for estimating a peak runoff from a small watershed. It was developed by Kuichling, 1889 for small drainage basins in urban areas. Unlike the TR55 method it does not provide any information pertaining to the runoff hydrograph shape. The rational method is expressed by the equation:

> Q = CiA

> where

> Q = design peak runoff rate, in cubic feet per second<br />
> C = runoff coefficient, dimensionless – defined as the ratio of the peak runoff rate to the rainfall intensity<br />
> i = rainfall intensity, in inches per hour, and<br />
> A = drainage area, in acres 

>> *Kuichling, E., 1889, The relation between the rainfall and the discharge of sewers in
populous districts. Transactions, American Society of Civil Engineers 20, 1–56.*

The Runoff Services API performs multiple procedures in order to compile a list of hydrologic variables that can be consumed by custom client applications. As documented by this page, which can also serve as a simple URL builder, the Runoff Services API is built following RESTful principles to ensure scalability and predictable URLs. JSON is returned by all API responses, including errors and example results and summaries for each resource. This API is intended to provide some guidance in working with the services.
