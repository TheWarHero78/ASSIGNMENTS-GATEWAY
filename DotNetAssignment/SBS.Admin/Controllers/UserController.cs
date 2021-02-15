using Newtonsoft.Json;
using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SBS.Admin.Controllers
{
    public class UserController : Controller
    {
        public static HttpClient webClient = new HttpClient();
        public ActionResult Index()
        {
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress+"/Users/getAllUser").Result;
            if (webResponse.IsSuccessStatusCode)
            {

                var response = webResponse.Content.ReadAsStringAsync().Result;
                var users = JsonConvert.DeserializeObject<List<UserViewModel>>(response);

                return View(users);
            }
            return View();
        }
      
    }
}
