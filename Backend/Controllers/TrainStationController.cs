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
    public class TrainStationController : ApiController
    {
        [Route("api/train_station/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Train_StationService.GetAll());
        }

        [Route("api/train_station/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var data = Train_StationService.GetById(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/train_station/create")]
        [HttpPost]
        public HttpResponseMessage Create(Train_StationModel t)
        {
            var res = Train_StationService.Create(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/train_station/update")]
        [HttpPost]
        public HttpResponseMessage Update(Train_StationModel t)
        {
            var res = Train_StationService.Update(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/train_station/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var res = Train_StationService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}
