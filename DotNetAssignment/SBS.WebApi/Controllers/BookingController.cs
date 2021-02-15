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
    public class BookingController : ApiController
    {
        private readonly IBooking _bookingManager;

        public BookingController(IBooking bookingManager)
        {
            _bookingManager = bookingManager;
        }
        [HttpGet]
        [Route("api/Bookings/getAllBooking")]
        public HttpResponseMessage getAllBooking()
        {
            List<BookingViewModel> result = _bookingManager.getAllBooking();
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
        [Route("api/Bookings/getBookingByExID")]
        public HttpResponseMessage getBookingByExID(string exID)
        {
            BookingViewModel result = _bookingManager.getBookingByExID(exID);
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
        [Route("api/Bookings/getAllBookingByCust")]
        public HttpResponseMessage getAllBookingByCust(string custExID)
        {
           List< BookingViewModel> result = _bookingManager.getAllBookingByCust(custExID);
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
        [Route("api/Bookings/registerBooking")]
        public HttpResponseMessage registerBooking([FromBody]BookingViewModel model)
        {
            bool result = _bookingManager.registerBooking(model);
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
        [Route("api/Bookings/updateBookingDetails")]
        public HttpResponseMessage updateBookingDetails([FromBody]BookingViewModel model)
        {
            bool result = _bookingManager.updateBookingDetails(model);
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
        [Route("api/Bookings/deleteBookingDetails")]
        public HttpResponseMessage deleteBookingDetails(string exID)
        {
            bool result = _bookingManager.deleteBookingDetails(exID);
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
