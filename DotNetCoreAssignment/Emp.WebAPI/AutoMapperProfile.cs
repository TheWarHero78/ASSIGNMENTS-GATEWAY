using DotNetCoreAssignment.Models;
using Emp.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace Emp.WebAPI
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee,EmployeeViewModel>();
            CreateMap<EmployeeViewModel, Employee>();
            CreateMap<UserViewModel, User>();
        }
    }
}
