using DotNetCoreAssignment.Models;
using DotNetCoreAssignment.Repository;
using Emp.BAL.Interface;
using Emp.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emp.BAL.Classes
{
    public class EmployeeManager : IEmployee
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {

            _employeeRepository = employeeRepository;
        }

        public bool AddEmployee(Employee employee)
        {
         
             return _employeeRepository.Add(employee);
        }

        public IList<Employee> GetAllEmployeeManagers()
        {
            var model = _employeeRepository.GetList(d => d.IsManager == true);

            return model;
        }

        public IList<Employee> GetAllEmployees()
        {
            var model = _employeeRepository.GetAll();
           
            return model;

        }

        public Employee GetEmployeeByID(long empID)
        {
            var model = _employeeRepository.GetSingle(d => d.Id == empID);           
            return model;
        }

        public bool RemoveEmployee(long empID)
        {
            var employee = _employeeRepository.GetSingle(d => d.Id == empID);
            return _employeeRepository.Remove(employee);
        }

        public bool UpdateEmployee(Employee employee)
        {
            return _employeeRepository.Update(employee);
        }
    }
}