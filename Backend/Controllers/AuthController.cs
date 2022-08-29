using BusinessLogic.BOs;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class AuthController : ApiController
    {
        [Route("api/auth/user")]
        [HttpPost]
        public HttpResponseMessage LoginUser(LoginModel obj)
        {
            var result = AuthServices.LoginUser(obj.Username, obj.Password);
            if(result!=null)
            {
                var cookie = new CookieHeaderValue("token", result);
                cookie.Expires = DateTimeOffset.Now.AddHours(5);
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";

                var res = Request.CreateResponse(HttpStatusCode.OK, result);
                res.Headers.AddCookies(new CookieHeaderValue[] { cookie });
                return res;
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid Username Or Password");
        }
    }
}
