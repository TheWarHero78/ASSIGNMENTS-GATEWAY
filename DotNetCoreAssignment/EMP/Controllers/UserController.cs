using Microsoft.AspNetCore.Mvc;

namespace EMP.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
