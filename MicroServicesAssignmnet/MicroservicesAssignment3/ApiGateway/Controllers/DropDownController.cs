using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGateway.Util;
using CommonObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiGateway.Controllers
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

       
        [HttpGet, Route("GetDealers")]
        public async Task<IEnumerable<DropdownDto>> GetRestaurants()
        {
            var cars = await HttpCall.GetRequest<List<DropdownDto>>("https://localhost:44331/api/Dropdown/GetCars");
            var drivers = await HttpCall.GetRequest<List<DropdownDto>>("https://localhost:44331/api/Dropdown/GetDrivers");
            cars.AddRange(drivers);
            var dealers = await HttpCall.GetRequest<List<DropdownDto>>("https://localhost:44331/api/Dropdown/GetDealers");
            drivers.AddRange(dealers);
               
            return cars;
        }
        [HttpGet, Route("GetBookings")]
        public async Task<IEnumerable<DropdownDto>> GetBookings()
        {
            var bookings = await HttpCall.GetRequest<List<DropdownDto>>("https://localhost:44333/api/Dropdown/GetBookings");
          
            return bookings;
        }
    }
}