using AutoMapper;
using DotNetCoreAssignment.Models;
using Emp.BAL.Interface;
using Emp.BusinessEntities.ViewModels;
using Emp.WebAPI.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [HeaderFilter]
    public class UserController : ControllerBase
    {
        private readonly IUser _context;
        private readonly IMapper _mapper;

        public UserController(IUser context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        

        [HttpPost]
        [Route("GetUser")]
        public IActionResult GetUser([FromBody] UserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            try
            {
                User user = _context.Validate(_mapper.Map<User>(model));
                if (user != null)
                {
                    return Ok(_mapper.Map<UserViewModel>(user));
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }


    

    //[HttpPost]
    //    public IActionResult CreateUser([FromBody] User model)
    //    {
    //        if (!ModelState.IsValid)
    //            return BadRequest("Not a valid model");
    //        if (_context.AddUser(model))
    //            return Ok();
    //        else
    //            return StatusCode(StatusCodes.Status500InternalServerError);
    //    }

        [HttpDelete("{Id}")]
        public IActionResult DeleteUser(int Id)
        {
            if (_context.RemoveUser(Id))
                return Ok();
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }
        [HttpPut]
        public IActionResult UpdateUser([FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            if (_context.UpdateUser(model))
                return Ok();
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
