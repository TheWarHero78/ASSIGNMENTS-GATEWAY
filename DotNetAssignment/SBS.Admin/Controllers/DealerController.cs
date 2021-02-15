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
    public class DealerController : Controller
    {


        Uri baseAddress = new Uri("http://localhost:64798/api");
        HttpClient webClient;
        public DealerController()
        {
            webClient = new HttpClient();
            webClient.BaseAddress = baseAddress;
        }
        // GET: Dealer

        public ActionResult Index()
        {

            //String para = "search=" + search + "&SortColumn=" + SortColumn + "&IconClass=" + IconClass + "&PageNo=" + PageNo;
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Dealers/getAllDealers").Result;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = webResponse.Content.ReadAsStringAsync().Result;
                var dealers = JsonConvert.DeserializeObject<List<DealerViewModel>>(response);
                //ViewBag.SortColumn = SortColumn;
                //ViewBag.IconClass = IconClass;
                //int NoOfRecordsPerPage = 5;
                //int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
                //int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
                //ViewBag.PageNo = PageNo;
                //ViewBag.NoOfPages = NoOfPages;
                //products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
                return View(dealers);
            }
            return View();
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Dealers/getDealerByExID?exID=" + id).Result;
            DealerViewModel dealer = null;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = webResponse.Content.ReadAsStringAsync().Result;
                dealer = JsonConvert.DeserializeObject<DealerViewModel>(response);
                return View(dealer);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Create()
        {
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Users/getAllUserDealer").Result;
            if (webResponse.IsSuccessStatusCode)
            {

                var Response = webResponse.Content.ReadAsStringAsync().Result;
                var dealers = JsonConvert.DeserializeObject<List<UserDealerDropDown>>(Response);
                TempData["UserID"] = new SelectList(dealers, "ID", "ID");


            }
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DealerViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage webResponse = webClient.PostAsJsonAsync(webClient.BaseAddress + "/Dealers/registerDealer", model).Result;
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

            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Dealers/getDealerByExID?exID=" + id).Result;
            DealerViewModel dealer = null;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = webResponse.Content.ReadAsStringAsync().Result;
                dealer = JsonConvert.DeserializeObject<DealerViewModel>(response);
                webResponse = webClient.GetAsync(webClient.BaseAddress + "/Users/getAllUserDealer").Result;
                if (webResponse.IsSuccessStatusCode)
                {
                    var Response = webResponse.Content.ReadAsStringAsync().Result;
                    var dealers = JsonConvert.DeserializeObject<List<UserDealerDropDown>>(Response);
                    TempData["UserID"] = new SelectList(dealers, "ID", "ID");
                }


                return View(dealer);
            }

            return HttpNotFound();


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DealerViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage webResponse = webClient.PutAsJsonAsync(webClient.BaseAddress + "/Dealers/updateDealerDetails", model).Result;
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
                HttpResponseMessage webResponse = webClient.PutAsJsonAsync(webClient.BaseAddress + "/Dealers/deleteDealerDetails?exID=", id).Result;
                if (webResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");


        }

    }
}
