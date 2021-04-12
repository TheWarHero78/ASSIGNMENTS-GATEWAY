using Emp.BusinessEntities.ViewModels;
using EMP.MVC.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;

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
                HttpResponseMessage response = GlobalVariable.webapiclient.PostAsJsonAsync("User/GetUser", reg).Result;
                if (response.IsSuccessStatusCode)

                    user = response.Content.ReadAsAsync<UserViewModel>().Result;
                HttpContext.Session.SetString("Message", ("Welcome User " + user.Email));

                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View("Error");
        }

        [AuthenticationFilter]
        public IActionResult Dashboard()
        {
            ViewBag.Message = HttpContext.Session.GetString("Message");
            return View();
        }
        [AuthenticationFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();


            return RedirectToAction("Login");
        }

    }
}
