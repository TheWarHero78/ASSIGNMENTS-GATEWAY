using DotNetCoreAssignment.Context;
using DotNetCoreAssignment.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreAssignment
{
    public static class IOConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
        
            services.AddDbContextFactory< EmployeeDbContext>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
