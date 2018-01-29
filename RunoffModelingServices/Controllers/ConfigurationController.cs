//------------------------------------------------------------------------------
//----- HttpController ---------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2017 WiM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping
//              
//  
//   purpose:   Handles resources through the HTTP uniform interface.
//
//discussion:   Controllers are objects which handle all interaction with resources. 
//              
//
// 

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Linq;

namespace RunoffModelingServices.Controllers
{
    [Route("[controller]")]
    public class ConfigurationController:Controller
    {
        private readonly IActionDescriptorCollectionProvider _provider;

        public ConfigurationController(IActionDescriptorCollectionProvider provider)
        {
            _provider = provider;
        }

        [HttpGet()]
        public IActionResult GetRoutes()
        {
            var routes = _provider.ActionDescriptors.Items.Where(a=>a.ActionConstraints !=null && a.RouteValues["Action"] != "GetRoutes").Select(x => new {
                Method = x.RouteValues["Action"],
                uri = x.AttributeRouteInfo.Template,
                Properties = x.Parameters.Where(p=>p.BindingInfo.BindingSource.DisplayName == "Query"). Select(p=> new {
                    Name = p.Name,
                    Type = p.ParameterType.Name
                })
            }).ToList();
            return Ok(routes);
        }
    }
}
