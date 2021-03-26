using BS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using System.Web.Routing;

namespace MetioRestAPI.App.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(string roles):
            base()
        {
            this.Roles = roles;
        }
        protected virtual CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.Current.User as CustomPrincipal;
            }
        }

        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            bool is_auth = (CurrentUser != null && !CurrentUser.IsInRole(Roles));
            is_auth =is_auth || CurrentUser == null;
            is_auth = is_auth || !CurrentUser.ValidateToken();

            return is_auth ? false : true;
        }
    }
}