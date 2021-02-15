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
    public class MechanicController : Controller
    {
        
        Uri baseAddress = new Uri("http://localhost:64798/api");
        HttpClient webClient;
        public MechanicController()
        {
            webClient = new HttpClient();
            webClient.BaseAddress = baseAddress;
        }
        public ActionResult Index()
        {
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Mechanics/getAllMechanics").Result;
            if (webResponse.IsSuccessStatusCode)
            {

                var response = webResponse.Content.ReadAsStringAsync().Result;
                var mechanics = JsonConvert.DeserializeObject<List<MechanicViewModel>>(response);
                return View(mechanics);
            }
            return View();
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Mechanics/getMechanicByExID?exID=" + id).Result;
            MechanicViewModel mechanic = null;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = webResponse.Content.ReadAsStringAsync().Result;
                mechanic = JsonConvert.DeserializeObject<MechanicViewModel>(response);
                return View(mechanic);
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
        public ActionResult Create(MechanicViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage webResponse = webClient.PostAsJsonAsync(webClient.BaseAddress + "/Mechanics/registerMechanic", model).Result;
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
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Mechanics/getMechanicByExID?exID=" + id).Result;
            MechanicViewModel mechanic = null;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = webResponse.Content.ReadAsStringAsync().Result;
                mechanic = JsonConvert.DeserializeObject<MechanicViewModel>(response);
                 webResponse = webClient.GetAsync(webClient.BaseAddress + "/Dealers/getAllDealerName").Result;
                if (webResponse.IsSuccessStatusCode)
                {

                    var Response = webResponse.Content.ReadAsStringAsync().Result;
                    var dealers = JsonConvert.DeserializeObject<List<DealerDropDown>>(Response);
                    TempData["DealerName"] = new SelectList(dealers, "ID", "Name");


                }
                return View(mechanic);
            }

            return HttpNotFound();


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MechanicViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage webResponse = webClient.PutAsJsonAsync(webClient.BaseAddress +"/Mechanics/updateMechanicDetails", model).Result;
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
                HttpResponseMessage webResponse = webClient.PutAsJsonAsync(webClient.BaseAddress +"/Mechanics/deleteMechanicDetails?exID=", id).Result;
                if (webResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");


        }




    }

}