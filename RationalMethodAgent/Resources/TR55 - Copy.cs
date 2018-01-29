//------------------------------------------------------------------------------
//----- Example ----------------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2017 WiM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping
//              
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
        
        public Double Precip { get; set; }
        public Double CurveNum { get; set; }
        public int PFreq { get; set; }
        public Double Q { get; set; }
        public Double Ia { get; set; }
        public Double S { get; set; } //potential maximum retention after runoff begins(in)

        #endregion
        #region Constructor
        public TR55()
        { }// end Site

        public TR55(Double precip, Double curvenum, int pfreq)
        {
            this.Precip = precip;
            this.CurveNum = curvenum;
            this.PFreq = pfreq;
            init();
        }//end Site
        #endregion
        #region Helper Method
        private void init()
        {
            S = 1000 / CurveNum - 10;
            Ia = 0.2 * S;
        }
        #endregion
    }//end Class
}
