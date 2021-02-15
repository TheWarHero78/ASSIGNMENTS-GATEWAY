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
    public class CustomerController : Controller
    {
        // GET: Customer
        Uri baseAddress = new Uri("http://localhost:64798/api");
        HttpClient webClient;
        public CustomerController()
        {
            webClient = new HttpClient();
            webClient.BaseAddress = baseAddress;
        }
        public ActionResult Index()
        {
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Customers/getAllCustomer").Result;
            if (webResponse.IsSuccessStatusCode)
            {

                var response = webResponse.Content.ReadAsStringAsync().Result;
                var customers = JsonConvert.DeserializeObject<List<CustomerViewModel>>(response);

                return View(customers);
            }
            return View();
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Customers/getCustomerByExID?exID=" + id).Result;
            CustomerViewModel customer = null;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = webResponse.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<CustomerViewModel>(response);
                return View(customer);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}