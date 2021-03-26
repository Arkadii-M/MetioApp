using MetioRestAPI.App.Security;
using MetioRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MetioRestAPI.Controllers
{
    public class ErrorController : ApiController
    {
      
        [HttpGet]
        [CustomAuthorize("admin")]
        public HttpResponseMessage HasAnyError()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK,"No errors");
            return response;
        }


        [HttpGet]
        [CustomAuthorize("admin")]
        public HttpResponseMessage GetError(int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Error with id="+id);
            return response;
        }

        [HttpPost]
        [CustomAuthorize("write")]
        public HttpResponseMessage PostAnError([FromBody] ErrorModel value)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Error posted"+value.dateTime.ToString());
            return response;
        }


        [HttpDelete]
        [CustomAuthorize("delete")]
        public HttpResponseMessage DeleteError(int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Error with id="+id.ToString()+" deleted.");
            return response;
        }
    }
}
