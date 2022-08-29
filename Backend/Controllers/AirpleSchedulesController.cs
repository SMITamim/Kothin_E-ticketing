using BusinessLogic.BOs;
using Business_Logic.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class AirpleSchedulesController : ApiController
    {
        [Route("api/airple_schedule/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Airple_SchedulesServices.GetAll());
        }

        [Route("api/airple_schedule/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var data = Airple_SchedulesServices.GetById(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/airple_schedule/create")]
        [HttpPost]
        public HttpResponseMessage Create(Airple_SchedulesModel t)
        {
            var res = Airple_SchedulesServices.Create(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/airple_schedule/update")]
        [HttpPost]
        public HttpResponseMessage Update(Airple_SchedulesModel t)
        {
            var res = Airple_SchedulesServices.Update(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/airple_schedule/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var res = Airple_SchedulesServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}

