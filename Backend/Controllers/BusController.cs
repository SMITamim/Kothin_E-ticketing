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
    public class BusController : ApiController
    {
        [Route("api/bus/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, BusServices.GetAll());
        }

        [Route("api/bus/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var data = BusServices.GetById(id);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

        }

        [Route("api/bus/create")]
        [HttpPost]
        public HttpResponseMessage Create(BusModel t)
        {
            var res = BusServices.Create(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/bus/update")]
        [HttpPost]
        public HttpResponseMessage Update(BusModel t)
        {
            var res = BusServices.Update(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/Bus/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var res = BusServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}
