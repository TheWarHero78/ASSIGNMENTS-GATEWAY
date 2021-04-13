using AutoMapper;
using DotNetCoreAssignment.Models;
using Emp.BAL.Interface;
using Emp.BusinessEntities.ViewModels;
using Emp.WebAPI.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Emp.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [HeaderFilter]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EmployeeController(IEmployee context, IMapper mapper, ILogger<EmployeeController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                var employee = _context.GetAllEmployees();
                return employee.Count > 0 ? (IActionResult)Ok(_mapper.Map<IList<EmployeeViewModel>>(employee)) : StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, ex.Message);

            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        [HttpGet]
        [Route("GetEmployeeManagers")]
        public IActionResult GetEmployeeManagers()
        {
            try
            {
                var employee = _context.GetAllEmployeeManagers();
                return employee.Count > 0 ? Ok(employee) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, ex.Message);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        [HttpGet("{Id}")]
        public IActionResult GetEmployeeById(int Id)
        {
            if (Id < 0)
            {
                return BadRequest("Not a valid id");
            }
            try
            {
                var employee = _context.GetEmployeeByID(Id);
                return employee != null ? Ok(_mapper.Map<EmployeeViewModel>(employee)) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, ex.Message);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeViewModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            try
            {
                return _context.AddEmployee(_mapper.Map<Employee>(model)) ? Ok() : StatusCode(StatusCodes.Status304NotModified);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, ex.Message);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteEmployee(int Id)
        {
            if (Id < 0)
            {
                return BadRequest("Not a valid id");
            }
            try
            {
                return _context.RemoveEmployee(Id) ? Ok() : StatusCode(StatusCodes.Status304NotModified);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, ex.Message);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            try
            {
                return _context.UpdateEmployee(_mapper.Map<Employee>(model)) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, ex.Message);

            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
