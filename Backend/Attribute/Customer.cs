using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Backend.Attribute
{
    public class Customer : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.GetCookies("token").FirstOrDefault();
            if (token == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "No Token Supplied");
            }
            else
            {
                string t = token.Cookies[0].Value;
                var rs = AuthServices.CheckToken(t);
                if (rs == false)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Supplied token is invalid or expired");
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}