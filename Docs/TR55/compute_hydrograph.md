### TR55 Compute Hydrograph Resource
Returns a response object of input parameters and time-series of the resulting tabular hydrograph variables, based on a user-selected location. Descriptions of variables can be found on the Home page in the Hydrologic Response Variable table.

The TR55 method is a simple technique for estimating peak runoff from a small watershed. It was developed by the Natural Resources Conservation Service (NRCS)(1986) for small drainage basins that are being urbanized.

The method begins with a rainfall amount uniformly imposed on the watershed over a specified time distribution. Mass rainfall is converted to mass runoff by using a runoff curve number (RCN). RCN is based on soils, plant cover, amount of impervious areas, interception, and surface storage. Runoff is then transformed into a hydrograph by using unit hydrograph theory and routing procedures that depend on runoff travel time through segments of the watershed (NRCS, 1986). The Runoff Modeling Services API collects time distributions from NOAA Atlas temporal distribution data available at [https://hdsc.nws.noaa.gov/hdsc/pfds/pfds_temporal.html] (https://hdsc.nws.noaa.gov/hdsc/pfds/pfds_temporal.html) to determine runoff travel time. TR55 is expressed by the equation:

>Q = (P-Iₐ)² / ((P-Iₐ)+S)
>
>where
>
>Q = runoff, in inches<br />
>P = rainfall, in inches<br />
>S = potential maximum retention after runoff begins, in inches, and<br />
>Iₐ = initial abstraction, in inches
>
>and
>
>Iₐ = 0.2S<br />
>S = (1000/RCN)-10
>
>>*Soil Conservation Service, 1986, Urban Hydrology for Small Watersheds, Technical Release 55 (2d ed.): Washington, D.C., United States Department of Agriculture, 210-VI-TR-55, 164 p. -- URL https://www.nrcs.usda.gov/Internet/FSE_DOCUMENTS/stelprdb1044171.pdf.*

##### Precipitation Duration (PDUR) Codes
The following precipitation duration codes will be accepted by the services

| Code  | Description |
| ------------- | ------------- |
| I6H2Y  | Maximum 6-hour precipitation that occurs on average once in 2 years  |
| I6H100Y  | Maximum 6-hour precipitation that occurs on average once in 100 years  |
| I24H2Y  | Maximum 24-hour precipitation that occurs on average once in 2 years  |
| I24H100Y  | Maximum 24-hour precipitation that occurs on average once in 100 years  |
