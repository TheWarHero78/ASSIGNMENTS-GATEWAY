using SBS.Business.Interfaces;
using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SBS.WebApi.Controllers
{
    public class ServiceController : ApiController
    {
        private readonly IService _serviceManager;

        public ServiceController(IService serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        [Route("api/Services/getAllServices")]
        public HttpResponseMessage getAllServices()
        {
            List<ServiceViewModel> result = _serviceManager.getAllServices();
            if (result != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
        }
        [HttpGet]
        [Route("api/Services/getServiceByExID")]
        public HttpResponseMessage getServiceByExID(string exID)
        {
            ServiceViewModel result = _serviceManager.getServiceByExID(exID);
            if (result != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
        }
        [HttpGet]
        [Route("api/Services/getAllServicesByDealer")]
        public HttpResponseMessage getAllServicesByDealer(string dealerExID)
        {
            List<ServiceViewModel> result = _serviceManager.getAllServicesByDealer(dealerExID);
            if (result != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
        }
        [HttpGet]
        [Route("api/Services/getAllServicesByDealerDrop")]
        public HttpResponseMessage getAllServicesByDealerDrop(string dealerExID)
        {
            List<ServiceDropDown> result = _serviceManager.getAllServicesByDealerDrop(dealerExID);
            if (result != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
        }
        [HttpPost]
        [Route("api/Services/registerService")]
        public HttpResponseMessage registerService([FromBody]ServiceViewModel model)
        {
            bool result = _serviceManager.registerService(model);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
        }
        [HttpPut]
        [Route("api/Services/updateServiceDetails")]
        public HttpResponseMessage updateMechanicDetails([FromBody]ServiceViewModel model)
        {
            bool result = _serviceManager.updateServiceDetails(model);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
        }
        [HttpDelete]
        [Route("api/Services/deleteServiceDetails")]
        public HttpResponseMessage deleteServiceDetails(string exID)
        {
            bool result = _serviceManager.deleteServiceDetails(exID);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
        }

    }
}
