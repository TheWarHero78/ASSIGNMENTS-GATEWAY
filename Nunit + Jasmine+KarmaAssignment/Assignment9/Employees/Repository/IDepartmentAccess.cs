using Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Repository
{
    public interface IDepartmentAccess
    {
        List<Department> GetDepartments();
        Department GetDepartment(int id);
        bool CreateDepartment(Department dept);
        bool CheckDeptExist(int id);
    }
}
