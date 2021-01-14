using BAL.Interfaces;
using Hotels_WebApi_AarshModi.AuthenticationFilters;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Hotels_WebApi_AarshModi.Controllers
{
    [AuthenticationFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BookingController : ApiController
    {
        private readonly IBooking _bookingManager;
        public BookingController(IBooking bookingManager)
        {
            _bookingManager = bookingManager;
        }

        [HttpGet]
        [Route("api/Booking/allBooking")]
        public IHttpActionResult changeBooking()
        {
            return Ok(_bookingManager.getAllBooking());
        }

        [HttpPut]
        [Route("api/Booking/updateBooking")]
        public IHttpActionResult changeBooking([FromBody]Booking model)
        {
            return Ok(_bookingManager.updateBooking(model));
        }

        [HttpPut]
        [Route("api/Booking/updateStatus")]
        public IHttpActionResult changeBookingStatus([FromBody]Booking model)
        {
            return Ok(_bookingManager.updateBookingStatus(model));
        }

        [HttpPut]
        [Route("api/Booking/deleteBooking")]
        public IHttpActionResult deleteBooking([FromBody]Booking model)
        {
            return Ok(_bookingManager.deleteBooking(model));
        }
    }
}
