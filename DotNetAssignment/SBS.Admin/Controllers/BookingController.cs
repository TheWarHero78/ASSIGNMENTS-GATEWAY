using Newtonsoft.Json;
using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SBS.Admin.Controllers
{
    public class BookingController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:64798/api");
        HttpClient webClient;
        public BookingController()
        {
            webClient = new HttpClient();
            webClient.BaseAddress = baseAddress;
        }
        // GET: Booking
        public ActionResult Index()
        {
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Bookings/getAllBooking").Result;
            if (webResponse.IsSuccessStatusCode)
            {

                var response = webResponse.Content.ReadAsStringAsync().Result;
                var bookings = JsonConvert.DeserializeObject<List<BookingViewModel>>(response);

                return View(bookings);
            }
            return View();
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Bookings/getBookingByExID?exID=" + id).Result;
            BookingViewModel booking = null;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = webResponse.Content.ReadAsStringAsync().Result;
                booking = JsonConvert.DeserializeObject<BookingViewModel>(response);
                return View(booking);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Bookings/getBookingByExID?exID=" + id).Result;
            BookingViewModel booking = null;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = webResponse.Content.ReadAsStringAsync().Result;
                booking = JsonConvert.DeserializeObject<BookingViewModel>(response);
                webResponse = webClient.GetAsync(webClient.BaseAddress + "/Dealers/getDealerByID?ID=" + booking.DealerID).Result;
                DealerViewModel dealer = null;
                if (webResponse.IsSuccessStatusCode)
                {
                    response = webResponse.Content.ReadAsStringAsync().Result;
                    dealer = JsonConvert.DeserializeObject<DealerViewModel>(response);
                }
                else
                {

                }

                webResponse = webClient.GetAsync(webClient.BaseAddress + "/Mechanics/getAllMechanicsByDealer?dealerExID=" + dealer.ExternalID.ToString()).Result;

                if (webResponse.IsSuccessStatusCode)
                {
                    response = webResponse.Content.ReadAsStringAsync().Result;
                    var mechanics = JsonConvert.DeserializeObject<List<MechanicDropDown>>(response);
                    TempData["mechanics"] = new SelectList(mechanics, "ID", "Name");
                }
                webResponse = webClient.GetAsync(webClient.BaseAddress + "/Services/getAllServicesByDealerDrop?dealerExID=" + dealer.ExternalID.ToString()).Result;

                if (webResponse.IsSuccessStatusCode)
                {
                    response = webResponse.Content.ReadAsStringAsync().Result;
                    var services = JsonConvert.DeserializeObject<List<ServiceDropDown>>(response);
                    TempData["services"] = new SelectList(services, "ID", "Name");
                }


                return View(booking);
            }

            return HttpNotFound();


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookingViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage webResponse = webClient.PutAsJsonAsync(webClient.BaseAddress + "/Bookings/updateBookingDetails", model).Result;
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
                HttpResponseMessage webResponse = webClient.PutAsJsonAsync(webClient.BaseAddress + "/Booking/deleteBookingDetails?exID=", id).Result;
                if (webResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            HttpResponseMessage webResponse = webClient.GetAsync(webClient.BaseAddress + "/Bookings/getAllBooking").Result;
            List<BookingViewModel> booking = null;
            if (webResponse.IsSuccessStatusCode)
            {

                var response = webResponse.Content.ReadAsStringAsync().Result;
                booking = JsonConvert.DeserializeObject<List<BookingViewModel>>(response);
            }
            gv.DataSource = booking;
            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);

            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");

        }
    }
}
