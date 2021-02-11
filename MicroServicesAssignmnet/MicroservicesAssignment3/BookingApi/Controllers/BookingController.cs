using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingApi.Services;
using BookingEntities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;

        public BookingController(ILogger<BookingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Booking> GetBookings()
        {
            return new BookingService().GetBookings();
        }


        [HttpGet, Route("GetBookings/{id}")]
        public IEnumerable<Booking> GetBookings(long id)
        {
            return new BookingService().GetBookings(id: id);
        }

    }
}
