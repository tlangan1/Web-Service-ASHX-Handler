using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Service_ASHX_Handler
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string type = context.Request.Params["type"];

            string returnValue = type;

            context.Response.Write(JsonConvert.SerializeObject(returnValue));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}