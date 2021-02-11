using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingApi.Services;
using CommonObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownController : ControllerBase
    {
        private readonly ILogger<DropDownController> _logger;

        public DropDownController(ILogger<DropDownController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get orders
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetBookings")]
        public IEnumerable<DropdownDto> GetBookings()
        {
            return new BookingService().GetBookings().Select(r => new DropdownDto { Id = r.ID, Name =r.CustomerID.ToString()  });
        }
    }
}