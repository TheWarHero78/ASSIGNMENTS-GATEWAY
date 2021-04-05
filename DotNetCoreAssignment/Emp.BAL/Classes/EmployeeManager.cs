using DotNetCoreAssignment.Models;
using DotNetCoreAssignment.Repository;
using Emp.BAL.Interface;
using Emp.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emp.BAL.Classes
{
    /// <summary>
    /// Employee manager class for dependency injection with employee repository 
    /// </summary>
    public class EmployeeManager : IEmployee
    {

        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Injecting Employee Repostory in Constructor
        /// </summary>
        /// <param name="employeeRepository"></param>
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {

            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Function to add employee 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns> returns a boolean value indication that emplyoee is added or not</returns>
        public bool AddEmployee(Employee employee)
        {         
             return _employeeRepository.Add(employee);
        }

        /// <summary>
        /// Function to getAllEmployee which are managers
        /// </summary>
        /// <returns>Returns a list employees</returns>
        public IList<Employee> GetAllEmployeeManagers()
        {
            var model = _employeeRepository.GetList(d => d.IsManager == true);

            return model;
        }

        /// <summary>
        /// Function to getAllEmployees
        /// </summary>
        /// <returns>Returns a list employees </returns>
        public IList<Employee> GetAllEmployees()
        {
            var model = _employeeRepository.GetAll();
           
            return model;

        }

        /// <summary>
        /// Function to retrive Single Employee with given ID
        /// </summary>
        /// <param name="empID"></param>
        /// <returns>Returns a single employee with matching id</returns>
        public Employee GetEmployeeByID(long empID)
        {
            var model = _employeeRepository.GetSingle(d => d.Id == empID);           
            return model;
        }

        /// <summary>
        /// Function to delete employee 
        /// </summary>
        /// <param name="empID"></param>
        /// <returns> returns a boolean value indication that emplyoee is deleted or not</returns>
        public bool RemoveEmployee(long empID)
        {
            var employee = _employeeRepository.GetSingle(d => d.Id == empID);
            return _employeeRepository.Remove(employee);
        }

        /// <summary>
        /// Function to Update employee details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>eturns a boolean value indication that emplyoee is updated or not</returns>
        public bool UpdateEmployee(Employee employee)
        {
            return _employeeRepository.Update(employee);
        }
    }
}