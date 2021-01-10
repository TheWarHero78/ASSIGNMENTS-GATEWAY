using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Products_AarshModi.Models;

namespace Products_AarshModi.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static HttpClient webClient = new HttpClient();
        // GET: Products
        public ActionResult Index(string[] ID, string search = "", string SortColumn = "ProductName", string IconClass = "fa-sort-amount-asc", int PageNo = 1)
        {
           
            String para = "search=" + search + "&SortColumn=" + SortColumn + "&IconClass=" + IconClass + "&PageNo=" + PageNo;
            HttpResponseMessage webResponse = webClient.GetAsync("http://localhost:64732/api/Products?" + para).Result;
            // products = webResponse.Content.ReadAsAsync<IEnumerable<tblProduct>>().Result;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var EmpResponse = webResponse.Content.ReadAsStringAsync().Result;
                var products = JsonConvert.DeserializeObject<List<Product>>(EmpResponse);
                ViewBag.SortColumn = SortColumn;
                ViewBag.IconClass = IconClass;
                int NoOfRecordsPerPage = 5;
                int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
                int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
                ViewBag.PageNo = PageNo;
                ViewBag.NoOfPages = NoOfPages;
                products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
                return View(products);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            HttpResponseMessage webResponse = null;
            String search = fc["search"];
            String x = fc["chkID"];
            if (!String.IsNullOrEmpty(search) || !String.IsNullOrEmpty(x))
            {
                if (!String.IsNullOrEmpty(x))
                {
                    String[] values = fc["chkID"].Split(',');

                    foreach (String element in values)
                    {
                        webResponse = webClient.DeleteAsync("http://localhost:64732/api/Products/" + element).Result;
                        if (webResponse.IsSuccessStatusCode)
                        {
                            String largeimage =fc["largeimg_"+element];
                            String smallImage = fc["smallimg_" + element];
                            removeImages(largeimage, smallImage);
                        }
                    }
                }





                String parameters = "search=" + search + "&SortColumn=ProductName&IconClass=fa-sort-amount-asc&PageNo=1";

                webResponse = webClient.GetAsync("http://localhost:64732/api/Products?" + parameters).Result;
                if (webResponse.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = webResponse.Content.ReadAsStringAsync().Result;
                    var products = JsonConvert.DeserializeObject<List<Product>>(EmpResponse);
                    ViewBag.SortColumn = "ProductName";
                    ViewBag.IconClass = "fa-sort-amount-asc";
                    ViewBag.search = search;
                    int NoOfRecordsPerPage = 5;
                    int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
                    int NoOfRecordsToSkip = (1 - 1) * NoOfRecordsPerPage;
                    ViewBag.PageNo = 1;
                    ViewBag.NoOfPages = NoOfPages;
                    products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
                    return View(products);
                }
            }




            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage webResponse = webClient.GetAsync("http://localhost:64732/api/Products/" + id).Result;
           Product products = null;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = webResponse.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<Product>(response);
            }
            if (products == null)
            {
                return HttpNotFound();
            }
            List<string> values = products.LargeImage.Split(',').ToList();
            values.Remove("");
            ViewBag.Images = values;
            ProductMetaData myUser = setproductMetaData(products);
            return View(myUser);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            HttpResponseMessage webResponse = webClient.GetAsync("http://localhost:64732/api/Categories").Result;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var EmpResponse = webResponse.Content.ReadAsStringAsync().Result;
                var Category = JsonConvert.DeserializeObject<List<Category>>(EmpResponse);
                TempData["Category"] = new SelectList(Category, "CategoryID", "CategoryName");
            }
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductMetaData MyProduct)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    String[] refs=generatePaths(MyProduct.LargeImage, MyProduct.SmallImage, MyProduct.ProductName.ToString());
                   
                    Product tblProduct = new Product();                    
                    tblProduct.ProductID = "";
                    tblProduct.ProductName = MyProduct.ProductName;
                    tblProduct.Price = MyProduct.Price;
                    tblProduct.Quantity = MyProduct.Quantity;
                    tblProduct.Category = MyProduct.Category;
                    tblProduct.ShortDescription = MyProduct.ShortDescription;
                    tblProduct.LongDescription = MyProduct.LongDescription;
                    tblProduct.LargeImage = refs[0];
                    tblProduct.SmallImage = refs[1];

                    HttpResponseMessage webResponse = webClient.PostAsJsonAsync("http://localhost:64732/api/Products", tblProduct).Result;
                    if (webResponse.IsSuccessStatusCode)
                    {
                        saveImages(MyProduct.LargeImage, MyProduct.SmallImage, MyProduct.ProductName.ToString());
                        return RedirectToAction("Index");
                    }
                    return View(MyProduct);


                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

            return View(MyProduct);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage webResponse = webClient.GetAsync("http://localhost:64732/api/Products/" + id).Result;
            Product products = null;
            if (webResponse.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var response = webResponse.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<Product>(response);
            }

            List<string> values = products.LargeImage.Split(',').ToList();
            values.Remove("");
            ViewBag.Images = values;
            ViewBag.SmallImage = products.SmallImage;
            ProductMetaData myUser = setproductMetaData(products);

            webResponse = webClient.GetAsync("http://localhost:64732/api/Categories").Result;
            if (webResponse.IsSuccessStatusCode)
            {
                var EmpResponse = webResponse.Content.ReadAsStringAsync().Result;
                var Category = JsonConvert.DeserializeObject<List<Category>>(EmpResponse);
                TempData["Category"] = new SelectList(Category, "CategoryID", "CategoryName", products.Category.ToString());
            }

            return View(myUser);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductMetaData MyProduct, FormCollection fc)
        {
            if (ModelState.IsValid)
            {
                String[] res = generatePaths(MyProduct.LargeImage, MyProduct.SmallImage, MyProduct.ProductName);
                MyProduct.LargeImagePath = res[0];
                MyProduct.SmallImagePath = res[1];
                ViewBag.Images = fc["largeimg"];
                ViewBag.SmallImage = fc["smallimg"];
                Product tblProduct = new Product();
                tblProduct.ProductID = MyProduct.ProductID;
                tblProduct.ProductName = MyProduct.ProductName;
                tblProduct.Price = MyProduct.Price;
                tblProduct.Quantity = MyProduct.Quantity;
                tblProduct.Category = MyProduct.Category;
                tblProduct.ShortDescription = MyProduct.ShortDescription;
                tblProduct.LongDescription = MyProduct.LongDescription;
                tblProduct.LargeImage = MyProduct.LargeImagePath;
                tblProduct.SmallImage = MyProduct.SmallImagePath;
                HttpResponseMessage webResponse = webClient.PutAsJsonAsync("http://localhost:64732/api/Products/" + tblProduct.ProductID + "", tblProduct).Result;
                if (webResponse.IsSuccessStatusCode)
                {
                    removeImages(fc["largeimg"].ToString(), fc["smallimg"].ToString());
                    saveImages(MyProduct.LargeImage, MyProduct.SmallImage, MyProduct.ProductName.ToString());
                    return RedirectToAction("Index");
                }

            }

            return View(MyProduct);
        }


        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string smallImage, string largeimage)
        {
            removeImages(largeimage, smallImage);
            HttpResponseMessage webResponse = webClient.DeleteAsync("http://localhost:64732/api/Products/" + id).Result;
            if (webResponse.IsSuccessStatusCode)
            {
                ViewBag.Message = "Deleted Successfully !!";
            }
            return RedirectToAction("Index");
        }
        public ProductMetaData setproductMetaData(Product products)
        {
            ProductMetaData myUser = new ProductMetaData();
            myUser.ProductID = products.ProductID;
            myUser.ProductName = products.ProductName;
            myUser.Price = products.Price;
            myUser.Quantity = products.Quantity;
            myUser.ShortDescription = products.ShortDescription;
            myUser.LongDescription = products.LongDescription;
            myUser.SmallImage = null;
            myUser.SmallImagePath = products.SmallImage;
            myUser.LargeImage = null;
            myUser.LargeImagePath = products.LargeImage;
            myUser.Category = products.tblCategory.CategoryName;
            return myUser;

        }


        public String[] generatePaths(HttpPostedFileBase[] reflarge, HttpPostedFileBase refsmall, String prodName)
        {
            String largePath = "";
            String smallPath = null;

            foreach (HttpPostedFileBase file in reflarge)
            {
                if (file != null)
                {
                    var InputFileName = Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/ImageUploads/LargeProductsImage/") + prodName + "_" + InputFileName);
                    largePath += prodName + "_" + InputFileName + ",";

                }
            }
            if (refsmall != null)
            {
                var InputFileName = Path.GetFileName(refsmall.FileName);
                var ServerSavePath = Path.Combine(Server.MapPath("~/ImageUploads/SmallProductsImage/") + prodName + "_" + InputFileName); ;
                smallPath = prodName + "_" + InputFileName;

            }
            String[] retPaths = { largePath, smallPath };
            return retPaths;
        }
        public bool removeImages(String reflarge, String refsmall)
        {
            bool isSuccessfull = true;
            try
            {
                List<string> values = reflarge.Split(',').ToList();
                values.Remove("");
                String fullPath;
                foreach (String element in values)
                {
                    fullPath = Request.MapPath("~/ImageUploads/LargeProductsImage/" + element);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                }
                fullPath = Request.MapPath("~/ImageUploads/SmallProductsImage/" + refsmall);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                isSuccessfull = false;
            }
            return isSuccessfull;
        }
        public bool saveImages(HttpPostedFileBase[] reflarge, HttpPostedFileBase refsmall, String prodName)
        {
            bool isSuccessfull = true;
            try
            {
                foreach (HttpPostedFileBase file in reflarge)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/ImageUploads/LargeProductsImage/") + prodName + "_" + InputFileName);
                        file.SaveAs(ServerSavePath);
                    }
                }
                if (refsmall != null)
                {
                    var InputFileName = Path.GetFileName(refsmall.FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/ImageUploads/SmallProductsImage/") + prodName + "_" + InputFileName);
                    refsmall.SaveAs(ServerSavePath);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                isSuccessfull = false;
            }
            return isSuccessfull;
        }
      
    }
}
