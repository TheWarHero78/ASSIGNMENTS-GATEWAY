﻿using DotNetCoreAssignment.Context;
using DotNetCoreAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreAssignment.Repository
{
    /// <summary>
    /// Class for User Repository Extending Generic Repository and Implementing interface IUserRepositoy
    /// </summary>
    public class UserRepository : GenericDataRepository<User>, IUserRepository
    {

        protected readonly DbContext dbContext;
        public UserRepository(DbContext context) : base((EmployeeDbContext)context)
        {
            this.dbContext = context;
        }

    }
}