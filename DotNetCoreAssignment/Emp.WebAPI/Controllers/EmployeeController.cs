using AutoMapper;
using DotNetCoreAssignment.Models;
using Emp.BAL.Interface;
using Emp.BusinessEntities.ViewModels;
using Emp.WebAPI.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public EmployeeController(IEmployee context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                IList<Employee> employee = _context.GetAllEmployees();
                if (employee.Count > 0)
                {
                    //  IList<EmployeeViewModel> empvm = null;

                    return Ok(_mapper.Map<IList<EmployeeViewModel>>(employee));
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        [HttpGet]
        [Route("GetEmployeeManagers")]
        public IActionResult GetEmployeeManagers()
        {
            try
            {
                IList<Employee> employee = _context.GetAllEmployeeManagers();
                if (employee.Count > 0)
                {
                    return Ok(employee);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {

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
                if (employee != null)
                {
                    return Ok(_mapper.Map<EmployeeViewModel>(employee));
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {

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
                if (_context.AddEmployee(_mapper.Map<Employee>(model)))
                    return Ok();
                else
                    return StatusCode(StatusCodes.Status304NotModified);
            }
            catch (Exception ex)
            {

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
                if (_context.RemoveEmployee(Id))
                    return Ok();
                else
                    return StatusCode(StatusCodes.Status304NotModified);
            }
            catch (Exception ex)
            {

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
                if (_context.UpdateEmployee(_mapper.Map<Employee>(model)))
                    return Ok();
                else
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {

            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
