//------------------------------------------------------------------------------
//----- Example ----------------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2017 WIM - USGS

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


namespace TR55Agent.Resources
{
    public class TR55
    {
        #region Properties
        public Double DRNAREA { get; set; } // drainage area (sq mi)
        public Double P { get; set; }  // rainfall (in)
        public Double RCN { get; set; }
        //public Double tDiff { get; set; }
        public int Duration { get; set; } // storm duration (6 or 24 hour)
        public Double Ia { get; set; } // initial abstraction (in)
        public Double S { get; set; } // potential maximum retention after runoff begins(in)
        public Double dP { get; set; } // incremental precipitation (in)
        public Double PIa { get; set; } // precip minus initial abstraction (in)
        public Double Pl { get; set; } // precipitation loss (in)
        public Double Pe { get; set; } // cumulative precipitation excess (in)
        public Double dPe { get; set; } // incremental precipitation loss (in)
        public Double Q { get; set; } // runoff (cfs)s

        #endregion
        #region Constructor
        public TR55()
        { }// end Site

        public TR55(Double precip, Double curvenum, int pdur)
        {
            this.P = precip;
            this.RCN = curvenum;
            this.Duration = pdur;
           
            init();
        }//end Site
        #endregion
        #region Helper Method
        //initializes 
        private void init()
        {
            S = 1000 / RCN - 10;
            Ia = 0.2 * S;
        }
        #endregion
    }//end Class
}
