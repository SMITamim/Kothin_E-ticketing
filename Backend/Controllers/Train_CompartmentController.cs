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
    public class Train_CompartmentController : ApiController
    {
        [Route("api/train_compartment/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK,Train_CompartmentServices.GetAll());
        }

        [Route("api/train_compartment/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var data = Train_CompartmentServices.GetById(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/train_compartment/create")]
        [HttpPost]
        public HttpResponseMessage Create(Train_CompartmentModel t)
        {
            var res = Train_CompartmentServices.Create(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/train_compartment/update/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(Train_CompartmentModel t)
        {
            var res = Train_CompartmentServices.Update(t);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/train_compartment/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var res = Train_CompartmentServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [Route("api/train_compartment/search")]
        [HttpPost]
        public HttpResponseMessage Search(SearchModel obj)
        {
            var data = Train_CompartmentServices.Search(obj.id, obj.type);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, data);

        }
    }

    public class SearchModel
    {
        public int id;
        public string type;
    }


}

