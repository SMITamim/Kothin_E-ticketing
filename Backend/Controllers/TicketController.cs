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
    public class TicketController : ApiController
    {
        [Route("api/ticket/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TicketServices.GetAll());
        }

        [Route("api/ticket/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var data = TicketServices.GetById(id);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

        }

        [Route("api/ticket/create")]
        [HttpPost]
        public HttpResponseMessage Create(TicketModel n)
        {
            var res = TicketServices.Create(n);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/ticket/update/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(TicketModel n)
        {
            var res = TicketServices.Update(n);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
        [Route("api/ticket/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var res = TicketServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}

