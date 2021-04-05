using DotNetCoreAssignment.Context;
using DotNetCoreAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreAssignment.Repository
{
    /// <summary>
    /// Class for Employee Repository Extending Generic Repository and Implementing interface IEmployeeRepositoy
    /// </summary>
    public class EmployeeRepository : GenericDataRepository<Employee>, IEmployeeRepository
    {
        protected readonly DbContext dbContext;

        public EmployeeRepository(DbContext context) : base((EmployeeDbContext)context)
        {
            this.dbContext = context;
        }

    }
}
