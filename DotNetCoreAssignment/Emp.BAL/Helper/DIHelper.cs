using Emp.BAL.Classes;
using Emp.BAL.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emp.BAL.Helper
{
    public static class DIHelper
    {
        public static void ConfigureService(ref IServiceCollection services)
        {
            DotNetCoreAssignment.IOConfig.ConfigureServices(ref services);
            services.AddScoped<IEmployee, EmployeeManager>();
        }
    }
}
