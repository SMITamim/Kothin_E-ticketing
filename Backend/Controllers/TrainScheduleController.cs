using BusinessLogic.Services;
using BusinessLogic.BOs;
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
    public class TrainScheduleController : ApiController
    {
        [Route("api/train_schedule/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Train_ScheduleServices.GetAll());
        }

        [Route("api/train_schedule/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var data = Train_ScheduleServices.GetById(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/train_schedule/create")]
        [HttpPost]
        public HttpResponseMessage Create(Train_ScheduleModel t)
        {
            var res = Train_ScheduleServices.Create(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/train_schedule/update")]
        [HttpPost]
        public HttpResponseMessage Update(Train_ScheduleModel t)
        {
            var res = Train_ScheduleServices.Update(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/train_schedule/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var res = Train_ScheduleServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}
