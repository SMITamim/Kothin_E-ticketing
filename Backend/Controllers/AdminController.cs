using BusinessLogic.BOs;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class AdminController : ApiController
    {
        [Route("api/admin/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, AdminServices.GetAll());
        }

        [Route("api/admin/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var data = AdminServices.GetById(id);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

        }

        [Route("api/admin/create")]
        [HttpPost]
        public HttpResponseMessage Create(AdminModel t)
        {
            var res = AdminServices.Create(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/admin/update")]
        [HttpPost]
        public HttpResponseMessage Update(AdminModel t)
        {
            var res = AdminServices.Update(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/admin/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var res = AdminServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}
