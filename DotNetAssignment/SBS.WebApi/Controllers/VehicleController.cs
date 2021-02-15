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
    public class VehicleController : ApiController
    {

        private readonly IVehicle _vehicleManager;

        public VehicleController(IVehicle vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }
        [HttpGet]
        [Route("api/Vehicles/getAllVehicle")]
        public HttpResponseMessage getAllVehicle()
        {
            List<VehicleViewModel> result = _vehicleManager.getAllVehicle();
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
        [Route("api/Vehicles/getVehicleByExID")]
        public HttpResponseMessage getVehicleByExID(string exID)
        {
            VehicleViewModel result = _vehicleManager.getVehicleByExID(exID);
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
        [Route("api/Vehicles/getAllVehiclesByCustomer")]
        public HttpResponseMessage getAllVehiclesByCustomer(string custExID)
        {
            List<VehicleViewModel> result = _vehicleManager.getAllVehiclesByCustomer(custExID);
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
        [Route("api/Vehicles/getAllVehicleByCustomer")]
        public HttpResponseMessage getAllVehicleByCustomer(string custExID)
        {
            List<VehicleDropDown> result = _vehicleManager.getAllVehicleByCustomer(custExID);
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
        [Route("api/Vehicles/registerVehicle")]
        public HttpResponseMessage registerVehicle([FromBody]VehicleViewModel model)
        {
            bool result = _vehicleManager.registerVehicle(model);
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
        [Route("api/Vehicles/updateVehicleDetails")]
        public HttpResponseMessage updateVehicleDetails([FromBody]VehicleViewModel model)
        {
            bool result = _vehicleManager.updateVehicleDetails(model);
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
        [Route("api/Vehicles/deleteVehicleDetails")]
        public HttpResponseMessage deleteVehicleDetails(string exID)
        {
            bool result = _vehicleManager.deleteVehicleDetails(exID);
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
