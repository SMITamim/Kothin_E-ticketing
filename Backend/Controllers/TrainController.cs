using BusinessLogic.BOs;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class TrainController : ApiController
    {
        [Route("api/train/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TrainServices.GetAll());
        }

        [Route("api/train/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var data = TrainServices.GetById(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/train/create")]
        [HttpPost]
        public HttpResponseMessage Create(TrainModel t)
        {
            var res = TrainServices.Create(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/train/update")]
        [HttpPost]
        public HttpResponseMessage Update(TrainModel t)
        {
            var res = TrainServices.Update(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/train/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var res = TrainServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/train/search/{id}")]
        [HttpGet]
        public HttpResponseMessage Search(string id)
        {
            int from = Int32.Parse(id.Split(',')[0]);
            int to = Int32.Parse(id.Split(',')[1]);
            var res = TrainSearchService.TrainSearch(from, to);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}
