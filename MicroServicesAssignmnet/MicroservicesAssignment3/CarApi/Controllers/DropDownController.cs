using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarApi.Services;
using CommonObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarApi.Controllers
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

        [HttpGet, Route("GetCars")]
        public IEnumerable<DropdownDto> GetCars()
        {
            return new CarService().GetCars().Select(r => new DropdownDto { Id = r.ID, Name = r.Type });
        }

        [HttpGet, Route("GetDrivers")]
        public IEnumerable<DropdownDto> GetDrivers()
        {
            return new DriverService().GetDrivers().Select(r => new DropdownDto { Id = r.ID, Name = r.Name });
        }
        [HttpGet, Route("GetDealers")]
        public IEnumerable<DropdownDto> GetDealers()
        {
            return new DealerService().GetDealers().Select(r => new DropdownDto { Id = r.ID, Name = r.Name });
        }
    }
}
