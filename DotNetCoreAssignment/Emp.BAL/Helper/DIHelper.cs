using Emp.BAL.Classes;
using Emp.BAL.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Emp.BAL.Helper
{
    /// <summary>
    /// Configuring Dependency Injection with Manager Classes
    /// </summary>
    public static class DIHelper
    {
        public static void ConfigureService(ref IServiceCollection services)
        {
            DotNetCoreAssignment.IOConfig.ConfigureServices(ref services);
            services.AddScoped<IEmployee, EmployeeManager>();
            services.AddScoped<IUser, UserManager>();
        }
    }
}
