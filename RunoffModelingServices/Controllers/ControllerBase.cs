using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TR55Agent;
using RationalMethodAgent;

namespace RunoffModelingServices.Controllers
{

    public abstract class ControllerBase: Controller
    {
        public ControllerBase()
        {
        }

        protected List<string> parse(string items)
        {
            if (items == null) items = string.Empty;
            char[] delimiterChars = { ';', ',' };
            return items.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries).Select(i=>i.Trim().ToLower()).ToList();
        }
        protected virtual Boolean isValid(object item)
        {
            try
            {
                var isvalid = this.TryValidateModel(item);
                return isvalid;
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
        }
        protected async Task<IActionResult> HandleExceptionAsync(Exception ex)
        {
            return await Task.Run(() => { return HandleException(ex); });
        }
        protected IActionResult HandleException(Exception ex)
        {
                return StatusCode(500, new Error(errorEnum.e_internalError, "An error occured while processing your request."));
        }


        protected struct Error
        {
            public int Code { get; private set; }
            public string Message { get; private set; }
            public string Content { get; private set; }

            public Error(errorEnum c, string msg) {
                this.Code = (int)c;
                this.Message = msg;
                this.Content = getContent(c);
            }
            public Error(errorEnum c)
            {
                this.Code = (int)c;
                this.Message = getDefaultmsg(c);
                this.Content = getContent(c);
            }

            private static string getContent(errorEnum code) {
                switch (code)
                {
                    case errorEnum.e_badRequest: return "Bad Request Received";
                    case errorEnum.e_notFound: return "Not Found";
                    case errorEnum.e_notAllowed: return "Method Not Allowed.";
                    case errorEnum.e_internalError: return "Internal Server Error Occured";
                    case errorEnum.e_unauthorize: return "Unauthorized";
                    default: return "Error not specified";                        
                }

            }
            private static string getDefaultmsg(errorEnum code)
            {
                switch (code)
                {
                    case errorEnum.e_badRequest: return "Object is invalid, please check you have populated all required properties and try again.";
                    case errorEnum.e_notFound: return "Object was not found.";
                    case errorEnum.e_notAllowed: return "Method not allowed.";
                    case errorEnum.e_internalError: return "Internal server error occured";
                    case errorEnum.e_unauthorize: return "Unauthorized to perform this action.";
                    default: return "Error not specified";

                }

            }


        }
        protected enum errorEnum
        {
            e_badRequest=400,
            e_unauthorize =401,
            e_notFound=404,
            e_notAllowed=405,
            e_internalError=500,
            e_error=0
        }
    }
}
