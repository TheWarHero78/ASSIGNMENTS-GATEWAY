using DotNetCoreAssignment.Models;
using Emp.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace Emp.WebAPI
{
    /// <summary>
    /// This class contains all the 
    /// mapping profiles required for automapper 
    /// to map with other models
    /// </summary>
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            //Employee Configuration 
            CreateMap<Employee,EmployeeViewModel>();
            CreateMap<EmployeeViewModel, Employee>();

            //User Configuration 
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();
        }
    }
}
