## Introduction
In cooperation with StreamStats, the runoff modeling services were developed to provide two simple hydrologic models that compute peak discharge for small watersheds, the NRCS Runoff Curve Number method (TR55) and the Rational Method.

### TR55
The TR55 method is a simple technique for estimating peak runoff from a small watershed. It was developed by the Natural Resources Conservation Service (NRCS), 1986 for small drainage basins that are being urbanized.

The method begins with a rainfall amount uniformly imposed on the watershed over a specified time distribution. Mass rainfall is converted to mass runoff by using a runoff curve number (RCN). RCN is based on soils, plant cover, amount of impervious areas, interception, and surface storage. Runoff is then transformed into a hydrograph by using unit hydrograph theory and routing procedures that depend on runoff travel time through segments of the watershed (USDA NRCS CED, TR-55, 1986). The Runoff Modeling Services API collects time distributions from NOAA Atlas temporal distribution data to determine runoff travel time. TR55 is expressed by the equation:

> Q = (P-Iₐ)² / ((P-Iₐ)+S)

> where

> Q = runoff, in inches
> P = rainfall, in inches
> S = potential maximum retention after runoff begins, in inches and 
> Iₐ = initial abstraction, in inches

>> *USDA Natural Resources Conservation Service (NRCS), June 1986, Technical Release 55: Urban Hydrology for Small Watersheds, 164 p. > [Also available at https://www.nrcs.usda.gov/Internet/FSE_DOCUMENTS/stelprdb1044171.pdf.]*
	 
### Rational Method
The Rational Method is another simple technique for estimating a peak runoff from a small watershed. It was developed by Kuichling, 1889 for small drainage basins in urban areas. Unlike the TR55 method it does not provide any information pertaining to the runoff hydrograph shape. The rational method is a valid hydrologic design tool for predicting peak flow rates from urban watersheds up to 50 acres. It is expressed by the equation:

> Q = CiA

> where

> Q = design peak runoff rate, in cubic feet per second
> C = runoff coefficient, dimensionless – defined as the ratio of the peak runoff rate to the rainfall intensity
> i = rainfall intensity, in inches per hour
> A = drainage area, in acres 

>> *Kuichling, E., 1889, The relation between the rainfall and the discharge of sewers in
populous districts. Transactions, American Society of Civil Engineers 20, 1–56.*

The Runoff Services API performs multiple procedures in order to compile a list of hydrologic variables that can be consumed by custom client applications. As documented by this page, which can also serve as a simple URL builder, the Runoff Services API is built following RESTful principles to ensure scalability and predictable URLs. JSON is returned by all API responses, including errors and example results and summaries for each resource. This API is intended to provide some guidance in working with the services.
