using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarApi.Services;
using CarsEntities.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        private readonly ILogger<DealerController> _logger;

        public DealerController(ILogger<DealerController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet, Route("GetDealers")]
        public IEnumerable<Dealer> Get()
        {
            return new DealerService().GetDealers();
        }

       
        [HttpGet, Route("GetCars/{id}")]
        public DealerCars GetDealerCars(long id)
        {
            return new DealerService().GetCar(id: id);
        }

        [HttpGet, Route("GetDrivers/{id}")]
        public DealerDrivers GetDealerDrivers(long id)
        {
            return new DealerService().GetDriver(id: id);
        }
    }
}
