using DotNetCoreAssignment.Context;
using DotNetCoreAssignment.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreAssignment
{
    /// <summary>
    /// Configuring Dependency Injection with Repository Classes
    /// </summary>
    public static class IOConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {

            services.AddDbContextFactory<EmployeeDbContext>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
