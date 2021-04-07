using AarshModi_CLPM.Models;

using CLPM.DAL.Repository.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AarshModi_CLPM.Controllers
{
    public class PassengerController : ApiController
    {
        private readonly IPassengerRepository _passengerManager;

        public PassengerController(IPassengerRepository passengerManager)
        {
            _passengerManager = passengerManager;
        }

        [HttpPost]
        [Route("api/Passengers/registerPassenger")]
        public Passenger registerPassenger([FromBody]Passenger model)
        {

            return _passengerManager.registerPassenger(model);

        }

        [HttpPut]
        [Route("api/Passengers/updatePassengerDetails")]
        public Passenger updatePassengerDetails([FromBody] Passenger model)
        {

            var result = _passengerManager.updatePassengerDetails(model);
            return result;

        }

        [HttpDelete]
        [Route("api/Passengers/deletePassengerDetails")]
        public bool deletePassengerDetails(String id)
        {

            bool result = _passengerManager.deletePassengerDetails(id);
            return result;


        }

        [HttpGet]
        [Route("api/Passengers/GetPassenger")]
        public Passenger GetPassenger(String id)
        {

            var passenger = _passengerManager.getPassengerByexID(id);
            if (passenger.FirstName != null)
            {
                return passenger;

            }
            else
            {
                return null;

            }
        }

        [HttpGet]
        [Route("api/Passengers/getAllPassenger")]
        public IList<Passenger> getAllPassenger()
        {
            return _passengerManager.getAllPassenger();

        }




    }
}

