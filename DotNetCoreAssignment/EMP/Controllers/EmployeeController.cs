


using Emp.BusinessEntities.ViewModels;
using EMP.MVC.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace EMP.Controllers
{
    [AuthenticationFilter]
    public class EmployeeController : Controller
    {
        [ResponseCache(Duration = 50000)]
        public IActionResult Index()
        {
            try
            {
                IList<EmployeeViewModel> employees;
                HttpResponseMessage response = GlobalVariable.webapiclient.GetAsync("Employee").Result;
                if (response.IsSuccessStatusCode)
                {
                    employees = response.Content.ReadAsAsync<IList<EmployeeViewModel>>().Result;
                    ViewData["Message"] = "The current time is:" + DateTime.Now.ToString();
                    return View(employees);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return View("Error");

        }


        public IActionResult Create(int Id = 0)
        {
            List<EmployeeViewModel> manager;
            HttpResponseMessage response = GlobalVariable.webapiclient.GetAsync("Employee/GetEmployeeManagers").Result;
            manager = response.Content.ReadAsAsync<List<EmployeeViewModel>>().Result;
            manager.Add(new EmployeeViewModel
            {
                Id = 0,
                Name = "No Manager",
            });

            TempData["manager"] = new SelectList(manager, "Id", "Name");
            if (Id == 0)
            {
                return View(new EmployeeViewModel());
            }
            else
            {
                response = GlobalVariable.webapiclient.GetAsync("Employee/" + Id.ToString()).Result;
                return View(response.Content.ReadAsAsync<EmployeeViewModel>().Result);
            }
        }

        public IActionResult Details(int Id = 0)
        {
            HttpResponseMessage response = GlobalVariable.webapiclient.GetAsync("Employee/" + Id.ToString()).Result;
            return View(response.Content.ReadAsAsync<EmployeeViewModel>().Result);
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            if (model.Id == 0)
            {
                HttpResponseMessage response = GlobalVariable.webapiclient.PostAsJsonAsync("Employee", model).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariable.webapiclient.PutAsJsonAsync("Employee/", model).Result;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.webapiclient.DeleteAsync("Employee/" + id.ToString()).Result;
          
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return RedirectToAction("Error", "Home");


        }
    }
}
