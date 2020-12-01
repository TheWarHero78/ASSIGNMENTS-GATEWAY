using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validations.Models;

namespace Validations.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]      
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                RedirectToAction("Index");
            }

          return View();
        }
    }
}