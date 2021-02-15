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
    public class VehicleController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:64798/api");
        HttpClient webClient;
        public VehicleController()
        {
            webClient = new HttpClient();
            webClient.BaseAddress = baseAddress;
        }
        public ActionResult Index()
        {
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Vehicles/getAllVehicle").Result;
            if (webResponse.IsSuccessStatusCode)
            {

                var response = webResponse.Content.ReadAsStringAsync().Result;
                var vehicles = JsonConvert.DeserializeObject<List<VehicleViewModel>>(response);

                return View(vehicles);
            }
            return View();
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Vehicles/getVehicleByExID?exID=" + id).Result;
            VehicleViewModel vehicle = null;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = webResponse.Content.ReadAsStringAsync().Result;
           vehicle = JsonConvert.DeserializeObject<VehicleViewModel>(response);
                return View(vehicle);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}