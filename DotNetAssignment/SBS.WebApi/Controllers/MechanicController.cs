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
    public class MechanicController : ApiController
    {
        private readonly IMechanic _mechanicManager;

        public MechanicController(IMechanic mechanicManager)
        {
            _mechanicManager = mechanicManager;
        }
        [HttpGet]
        [Route("api/Mechanics/getAllMechanics")]
        public HttpResponseMessage getAllMechanics()
        {
            List<MechanicViewModel> result = _mechanicManager.getAllMechanics();
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
        [Route("api/Mechanics/getMechanicByExID")]
        public HttpResponseMessage getMechanicByExID(string exID)
        {
            MechanicViewModel result = _mechanicManager.getMechanicByExID(exID);
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
        [Route("api/Mechanics/getAllMechanicsByDealer")]
        public HttpResponseMessage getAllMechanicsByDealer(string dealerExID)
        {
           List<MechanicDropDown> result = _mechanicManager.getAllMechanicsByDealer(dealerExID);
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
        [Route("api/Mechanics/registerMechanic")]
        public HttpResponseMessage registerMechanic([FromBody]MechanicViewModel model)
        {
            bool result = _mechanicManager.registerMechanic(model);
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
        [Route("api/Mechanics/updateMechanicDetails")]
        public HttpResponseMessage updateMechanicDetails([FromBody]MechanicViewModel model)
        {
            bool result = _mechanicManager.updateMechanicDetails(model);
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
        [Route("api/Mechanics/deleteMechanicDetails")]
        public HttpResponseMessage deleteMechanicDetails(string exID)
        {
            bool result = _mechanicManager.deleteMechanicDetails(exID);
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
