//------------------------------------------------------------------------------
//----- Example ----------------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2017 WiM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping,
//              Tara A. Gross USGS Colorado Water Science Center
//  
//   purpose:   Represents Wateruse Configureation
//
//discussion:   Simple POCO object class  
//
// 
using System;
using System.Collections.Generic;


namespace RationalMethodAgent.Resources
{
    public class RationalMethod
    {
        #region Properties
        
        public Double PrecipI { get; set; }  // precip intensity (inches/hour)
        public Double RunoffCoeff { get; set; } // rational runoff coefficient
        public Double DrainageArea { get; set; } // drainage area (sq/mi)
        public Double Q { get; set; } // runoff (cfs)
        public int Duration { get; set; } // storm duration (6 or 24 hour)

        #endregion
        #region Constructor
        public RationalMethod()
        { }// end Site

        public RationalMethod(Double area, Double precipint, Double rcoeff, int dur)
        {
            this.PrecipI = precipint;
            this.RunoffCoeff = rcoeff;
            this.DrainageArea = area;
            this.Duration = dur;
        }//end Site
        #endregion
        #region Helper Method
        #endregion
    }//end Class
}
