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
    public class ServiceController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:64798/api");
        HttpClient webClient;
        public ServiceController()
        {
            webClient = new HttpClient();
            webClient.BaseAddress = baseAddress;
        }
        public ActionResult Index()
        {
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Services/getAllServices").Result;
            if (webResponse.IsSuccessStatusCode)
            {

                var response = webResponse.Content.ReadAsStringAsync().Result;
                var services = JsonConvert.DeserializeObject<List<ServiceViewModel>>(response);
                return View(services);
            }
            return View();
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Services/getServiceByExID?exID=" + id).Result;
            ServiceViewModel service = null;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = webResponse.Content.ReadAsStringAsync().Result;
                service = JsonConvert.DeserializeObject<ServiceViewModel>(response);
                return View(service);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Create()
        {
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Dealers/getAllDealerName").Result;
            if (webResponse.IsSuccessStatusCode)
            {

                var Response = webResponse.Content.ReadAsStringAsync().Result;
                var dealers = JsonConvert.DeserializeObject<List<DealerDropDown>>(Response);
                TempData["DealerName"] = new SelectList(dealers, "ID", "Name");


            }
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage webResponse = webClient.PostAsJsonAsync(webClient.BaseAddress + "/Services/registerService", model).Result;
                if (webResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Services/getServiceByExID?exID=" + id).Result;
            ServiceViewModel service = null;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = webResponse.Content.ReadAsStringAsync().Result;
                service = JsonConvert.DeserializeObject<ServiceViewModel>(response);
                 webResponse = webClient.GetAsync(webClient.BaseAddress + "/Dealers/getAllDealerName").Result;
                if (webResponse.IsSuccessStatusCode)
                {

                    var Response = webResponse.Content.ReadAsStringAsync().Result;
                    var dealers = JsonConvert.DeserializeObject<List<DealerDropDown>>(Response);
                    TempData["DealerName"] = new SelectList(dealers, "ID", "Name");

                    
                }
                return View(service);
            }

            return HttpNotFound();


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage webResponse = webClient.PutAsJsonAsync(webClient.BaseAddress + "/Services/updateServiceDetails", model).Result;
                if (webResponse.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }


            }

            return View(model);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage webResponse = webClient.PutAsJsonAsync(webClient.BaseAddress + "/Services/deleteServiceDetails?exID=", id).Result;
                if (webResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }



            }
            return RedirectToAction("Index");


        }

    }
}