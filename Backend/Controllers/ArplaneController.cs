using BusinessLogic.BOs;
using BusinessLogic.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class ArplaneController : ApiController
    {
        [Route("api/airplane/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, AirplaneService.GetAll());
        }

        [Route("api/airplane/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var data = AirplaneService.GetById(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/airplane/create")]
        [HttpPost]
        public HttpResponseMessage Create(AirplaneModel t)
        {
            var res = AirplaneService.Create(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/airplane/update")]
        [HttpPost]
        public HttpResponseMessage Update(AirplaneModel t)
        {
            var res = AirplaneService.Update(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/airplane/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var res = AirplaneService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }

}

