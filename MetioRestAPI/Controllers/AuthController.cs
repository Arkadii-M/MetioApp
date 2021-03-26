using DAL.Concrete;
using MetioRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace MetioRestAPI.Controllers
{
    public class AuthController : ApiController
    {
        protected readonly BS.Interface.IAuthManager _authManager;
        protected readonly BS.Interface.ITokenManager _tokenManager;
        public AuthController(BS.Interface.IAuthManager authManager, BS.Interface.ITokenManager tokenManager)
        {
            _authManager = authManager;
            _tokenManager = tokenManager;

        }


        [HttpGet]
        [Route("api/auth")]
        public HttpResponseMessage IsValidCredentials([FromBody]LoginModel value)
        {
            try
            {
                if (_authManager.Authorize(value.login, value.password))
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK,"Credential are valid");
                    return response;
                }
                else
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid credentional");
                    return response;
                }
            }
            catch (Exception exp)
            {
                //log
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }

        }
        [HttpPost]
        [Route("api/auth")]
        public HttpResponseMessage Login([FromBody] LoginModel value)
        {
            try
            {
                if (_authManager.Authorize(value.login, value.password))
                {
                    var token = _tokenManager.GenerateNewToken(value.login,minutes:10);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, Newtonsoft.Json.JsonConvert.SerializeObject(token));
                    return response;
                }
                else
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid credentional");
                    return response;
                }
            }
            catch (Exception exp)
            {
                //log
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }

        }

    }
}
