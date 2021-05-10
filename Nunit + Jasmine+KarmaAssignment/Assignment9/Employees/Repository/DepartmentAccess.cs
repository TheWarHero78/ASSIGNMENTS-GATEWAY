using Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees.Repository
{
    /// <summary>
    /// The Department Data Access
    /// </summary>
    public class DepartmentAccess : IDepartmentAccess
    {
        DBEmpEntities ctx;
        public DepartmentAccess()
        {
            ctx = new DBEmpEntities();
        }
        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartments()
        {
            var depts = ctx.Departments.ToList();
            return depts;
        }
        /// <summary>
        /// Get Department base on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetDepartment(int id)
        {
            var dept = ctx.Departments.Find(id);
            return dept;
        }
        /// <summary>
        /// Create Department
        /// </summary>
        /// <param name="dept"></param>
        public bool CreateDepartment(Department dept)
        {
            ctx.Departments.Add(dept);
           if(ctx.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check whether Department Exist or Not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckDeptExist(int id)
        {
            var dept = ctx.Departments.Find(id);
            if (dept != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}