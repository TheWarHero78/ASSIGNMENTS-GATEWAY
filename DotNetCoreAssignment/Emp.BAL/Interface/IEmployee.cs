using DotNetCoreAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emp.BAL.Interface
{
    public interface IEmployee
    {
        IList<Employee> GetAllEmployees();
        IList<Employee> GetAllEmployeeManagers();
        Employee GetEmployeeByID(long empID);
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool RemoveEmployee(long empID);

    }
}
