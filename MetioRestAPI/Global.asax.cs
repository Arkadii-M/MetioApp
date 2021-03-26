using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MetioRestAPI.App.Security;
namespace MetioRestAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }


        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var token = Request.Headers["token"];

            if (token != null)
            {
                
                CustomPrincipal principal = new CustomPrincipal(token);

                if(principal.IsValidTokenForm())
                {
                    HttpContext.Current.User = principal;
                }
                else
                {
                    HttpContext.Current.User = null;
                }
                
            }

        }
    }
}
