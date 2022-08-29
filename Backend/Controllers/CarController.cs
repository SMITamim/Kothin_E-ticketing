using BusinessLogic.BOs;
using BusinessLogic.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class CarController : ApiController
    {
        [Route("api/car/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, CarService.GetAll());
        }

        [Route("api/car/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var data = CarService.GetById(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/car/create")]
        [HttpPost]
        public HttpResponseMessage Create(CarModel t)
        {
            var res = CarService.Create(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/car/update")]
        [HttpPost]
        public HttpResponseMessage Update(CarModel t)
        {
            var res = CarService.Update(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/car/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var res = CarService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }

}

