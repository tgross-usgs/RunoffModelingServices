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
using TR55Agent.Resources;


namespace TR55Agent
{
    public interface ITR55Agent
    {
        //methods
        TR55 Execute(double precip, double crvnum, int dur);
        Dictionary<double, TR55> ExecuteHydro(double area, double precip, double crvnum, int dur, Dictionary<double, double> hyeto);
    }
    public class TR55Agent : ITR55Agent
    {
        #region Properties
        public Dictionary<string, TR55> hydro;
        #endregion

        #region Methods
        //retrieves Q 
        public TR55 Execute(double precip, double crvnum, int dur)
        {
            try
            {
                TR55 Result = new TR55(precip, crvnum, dur);

                Result.Q = CalcQin(precip, crvnum, Result.Ia);
                
                return Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
        //returns unit hydrograph data
        public Dictionary<double, TR55> ExecuteHydro(double area, double precip, double crvnum, int dur, Dictionary<double, double> hyetograph)
        {
            double tempP = 0;
            double tempPe = 0;
            double tempT = 0;
            double tdiff = 0;
            Dictionary<double, TR55> hydrotable = new Dictionary<double, TR55>();

            int count1 = hyetograph.Count;

            hyetograph = AddOne2Hyetograph(count1, hyetograph);

            for (int i = 0; i < hyetograph.Count; i++)
            {
                TR55 hydrodata = new TR55(precip, crvnum, dur);
                double d = hyetograph.ElementAt(i).Key;
                double p = hyetograph.ElementAt(i).Value * 0.01;
                double t;

                t = d * 60;
                //t = d * 0.01 * dur * 60;
                tdiff = t - tempT;
                hydrodata.DRNAREA = area;
                hydrodata.P = p * precip;
                hydrodata.dP = (p * precip) - tempP;
                hydrodata.PIa = hydrodata.P - hydrodata.Ia;
                if (hydrodata.PIa <= 0)
                {
                    hydrodata.Pe = 0;
                    hydrodata.dPe = 0; 
                    hydrodata.Pl = hydrodata.dP - hydrodata.dPe; 
                }
                else
                {
                    hydrodata.Pe = Math.Pow(hydrodata.P - 0.2 * hydrodata.S, 2)/(hydrodata.P + 0.8 * hydrodata.S);
                    hydrodata.dPe = hydrodata.Pe - tempPe;
                    hydrodata.Pl = hydrodata.dP - hydrodata.dPe;
                }

                if (hydrodata.dP <= 0)
                {
                    hydrodata.Q = 0;
                }
                else
                {
                    hydrodata.Q = CalcQ(hydrodata.DRNAREA, hydrodata.dPe, crvnum, tdiff, hydrodata.Ia);
                }
                

                hydrotable.Add(d, hydrodata);

                tempT = t;
                tempP = hydrodata.P;
                tempPe = hydrodata.Pe;
            }
            return hydrotable;
        }
        #endregion
        #region HELPER METHODS
        //calculates Q in inches
        private double CalcQin(double dp, double crvnum, double ia)
        {
            double Q = (Math.Pow(dp - ia, 2)) / (dp + 0.8 * (1000 / crvnum - 10));

            return Q;
        }
        //calculates Q in cubic feet per second
        private double CalcQ(double area, double dpe, double crvnum, double tdiff, double ia)
        {
            double Q = dpe / 12 * area * Math.Pow(5280, 2) / (tdiff * 60);

            return Q;
        }
        //adds additional time step to hyetograph
        private Dictionary<double, double> AddOne2Hyetograph(int count1, Dictionary<double, double> hyetograph)
        {
            double k = hyetograph.ElementAt(1).Key + hyetograph.ElementAt(count1 - 1).Key;
            double v = hyetograph.ElementAt(count1 - 1).Value;

            hyetograph.Add(k, v);
            return hyetograph;
        }
        #endregion
    }
}
