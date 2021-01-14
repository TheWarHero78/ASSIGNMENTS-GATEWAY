using BAL.Interfaces;
using Models.Models;
using Hotels_WebApi_AarshModi.AuthenticationFilters;
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
    public class HotelController : ApiController
    {
        private readonly IHotel _hotelManager;
        public HotelController()
        {
            
        }
        public HotelController(IHotel hotelManager)
        {
            _hotelManager = hotelManager;   
        }

        [HttpGet]
        [Route("api/Hotel/showAll")]
        public IHttpActionResult Hotels()
        {
            return Ok(_hotelManager.getAllHolels());
        }

       

        [HttpGet]
        [Route("api/Hotel/find/{id}")]
        public IHttpActionResult Hotel(long id)
        {
            return Ok(_hotelManager.getHotel(id));
        }

        [HttpPost]
        [Route("api/Hotel/addHotel")]
        public IHttpActionResult makeAhotel([FromBody]Hotel model)
        {
            return Ok(_hotelManager.createHotel(model));
        }

    }
}
