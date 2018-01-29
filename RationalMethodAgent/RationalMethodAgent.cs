//------------------------------------------------------------------------------
//----- ServiceAgent -------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2017 WiM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping,
//              Tara A. Gross USGS Colorado Water Science Center
//  
//   purpose:   The service agent is responsible for initiating the service call, 
//              capturing the data that's returned and forwarding the data back to 
//              the requestor.
//
//discussion:   delegated hunting and gathering responsibilities.   
//
// 

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using WiM.Utilities;
using RationalMethodAgent.Resources;


namespace RationalMethodAgent
{
    public interface IRationalMethodAgent
    {
        //methods
        RationalMethod Execute(double area, double rain, double rcoeff, int dur);
    }
    public class RationalMethodAgent : IRationalMethodAgent
    {
        #region Properties
        #endregion

        #region Methods
        //retrieves Q 
        public RationalMethod Execute(double area, double rain, double rcoeff, int dur)
        {
            try
            {
                RationalMethod Result = new RationalMethod(area, rain, rcoeff, dur);

                Result.Q = CalcQ(area, rain, rcoeff, dur);
                
                return Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
        #endregion
        #region HELPER METHODS
        //calculates Q as ciA
        private double CalcQ(double area, double rain, double rcoeff, int dur)
        {
            double Q = rcoeff * (rain / dur) * (area * 640); // 640 is multiplied by the area to convert sq mi to acres

            return Q;
        }
        #endregion
    }
}
