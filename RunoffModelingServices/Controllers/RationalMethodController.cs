//------------------------------------------------------------------------------
//----- HttpController ---------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2017 WIM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping,
//              Tara A. Gross USGS Colorado Water Science Center
//  
//   purpose:   Handles resources through the HTTP uniform interface.
//
//discussion:   Controllers are objects which handle all interaction with resources. 
//              
//
// 

using Microsoft.AspNetCore.Mvc;
using System;
using TR55Agent;
using System.Threading.Tasks;
using System.Collections.Generic;
using TR55Agent.Resources;
using System.Linq;
using Microsoft.Extensions.Options;
using RunoffModelingServices.Resources;
using RunoffModelingServices.ServiceAgents;
using RationalMethodAgent;
using WIM.Services.Attributes;

namespace RunoffModelingServices.Controllers
{
    [Route("[controller]")]
    [APIDescription(type = DescriptionType.e_string, Description = "The Rational Method resource represents the Rational Method hydrologic model. Resultants return the calculated peak runoff and input parameters.")]
    public class RationalMethodController : ControllerBase
    {
        #region PROPERTIES 
        public IRationalMethodAgent agent { get; set; }
        
        #endregion
        //private TDSettings tempdistSettings { get; set; }
        public RationalMethodController(IRationalMethodAgent sa) : base()
        {
            this.agent = sa;
        }
        #region METHODS
        //collects data from client, checks for valid precip, calls method to calculate Q
        [HttpGet(Name = "Compute")]
        [APIDescription(type = DescriptionType.e_link, Description = "/Docs/RationalMethod/compute.md")]
        public async Task<IActionResult> Get(double area, double precipint, double rcoeff, string pdur)
        {
            try
            {
                if (precipint < 0 || precipint > 100)
                    return new BadRequestObjectResult("One or more of the parameters are invalid.");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

            int Hlocation = pdur.IndexOf("H") - 1;
            int dur = Convert.ToInt32(pdur.Substring(1, Hlocation));

            return Ok(agent.Execute(area, precipint, rcoeff, dur));
        }
        #endregion
    }
}
