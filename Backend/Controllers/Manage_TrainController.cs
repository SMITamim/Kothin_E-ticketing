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
    public class Manage_TrainController : ApiController
    {

            [Route("api/manage_train/")]
            [HttpGet]
            public HttpResponseMessage GetAll()
            {
                return Request.CreateResponse(HttpStatusCode.OK, Manage_TrainServices.GetAll());
            }

            [Route("api/manage_train/{id}")]
            [HttpGet]
            public HttpResponseMessage GetById(int id)
            {
                var data = Manage_TrainServices.GetById(id);
                if (data == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, data);

            }

            [Route("api/manage_train/create")]
            [HttpPost]
            public HttpResponseMessage Create(Manage_TrainModel t)
            {
                var res = Manage_TrainServices.Create(t);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }

            [Route("api/manage_train/update/{id}")]
            [HttpPost]
            public HttpResponseMessage Update(Manage_TrainModel t)
            {
                var res = Manage_TrainServices.Update(t);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }

            [Route("api/manage_train/delete/{id}")]
            [HttpPost]
            public HttpResponseMessage Delete(int id)
            {
                var res = Manage_TrainServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
        }

    }

