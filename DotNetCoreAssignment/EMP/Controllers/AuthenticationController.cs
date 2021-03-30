using Emp.BusinessEntities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMP.MVC.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserViewModel reg)
        {
            try
            {
                UserViewModel user = new UserViewModel();
                HttpResponseMessage response = GlobalVariable.webapiclient.PostAsJsonAsync("User", reg).Result;
                if (response.IsSuccessStatusCode)

                    user = response.Content.ReadAsAsync<UserViewModel>().Result;
                HttpContext.Session.SetString("Message", ("Welcome User " + user.Email));

                return View("Dashboard");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View("Error");
        }
        public IActionResult Dashboard()
        {
            ViewBag.Message = HttpContext.Session.GetString("Message");
            return View();
        }


    }
}
