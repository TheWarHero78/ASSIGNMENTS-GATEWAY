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

namespace Hotels_WebApi_AarshModi
{
    [AuthenticationFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RoomController : ApiController
    {
        private readonly IRoom _roomManager;
        public RoomController(IRoom roomManager)
        {
            _roomManager = roomManager;
        }

        [HttpGet]
        [Route("api/Room/showAll")]
        public IHttpActionResult allRooms(string city = null, decimal? pincode = null, int? price = null, string category = null)
        {
            return Ok(_roomManager.searchRoom(city,pincode,price,category));
        }

        [HttpPost]
        [Route("api/Room/create")]
        public IHttpActionResult makeARoom([FromBody]Room model)
        {
            return Ok(_roomManager.createRoom(model));
        }

        [HttpGet]
        [Route("api/Room/find/{id}/{date}")]
        public IHttpActionResult makeARoom(long id,DateTime date)
        {
            return Ok(_roomManager.checkRoomAvailability(id,date));
        }

        [HttpPost]
        [Route("api/Room/book")]
        public IHttpActionResult bookARoom([FromBody]Booking model)
        {
            return Ok(_roomManager.bookRoom(model));
        }
    }
}
