//------------------------------------------------------------------------------
//----- HttpController ---------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2017 WiM - USGS

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


namespace RunoffModelingServices.Controllers
{
    [Route("[controller]")]
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
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] double area, [FromQuery] double? precipint, [FromQuery] double rcoeff, [FromQuery] string pdur)
        {
            try
            {
                if (!precipint.HasValue || precipint < 0 || precipint > 100)
                    return new BadRequestObjectResult("One or more of the parameters are invalid.");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

            int Hlocation = pdur.IndexOf("H") - 1;
            int dur = Convert.ToInt32(pdur.Substring(1, Hlocation));

            return Ok(agent.Execute(area, precipint.Value, rcoeff, dur));
        }
        #endregion
    }
}
