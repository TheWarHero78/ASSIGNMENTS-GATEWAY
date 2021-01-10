using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using Products_AarshModi.Models;

namespace Products_AarshModi.Controllers
{
   
    public class UsersController : Controller
    {      
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static HttpClient webClient = new HttpClient();
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Session["FullName"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    HttpResponseMessage webResponse = webClient.GetAsync("http://localhost:64732/api/Users/?id=" + email).Result;
                    if (webResponse.IsSuccessStatusCode)
                    {
                        var EmpResponse = webResponse.Content.ReadAsStringAsync().Result;
                        var products = JsonConvert.DeserializeObject<User>(EmpResponse);
                        var f_password = GetMD5(password);
                        if (products.Email.Equals(email) && products.Password.Equals(f_password))
                        {
                            //add session
                            Session["FullName"] = products.FirstName + " " + products.LastName;
                            Session["Email"] = products.Email;
                            Session["idUser"] = products.UserID;
                            logger.Info("Login Successfull for " + Session["FullName"]);
                            FormsAuthentication.SetAuthCookie(email, false);
                            return RedirectToAction("Dashboard", "Users");
                        }
                        else
                        {
                            ViewBag.Message = "Login failed..Password or Email Wrong!!";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
              
                logger.Error(ex.Message, ex);
            }
            ViewBag.Message = "There was a error for login..Please try again after some time!!";
            return View();
        }
        // GET: Users/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
         
            return View();
        }
       
        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(UserMetaData MyUser)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    User user = new User();                    
                    user.UserID = "";
                    user.FirstName = MyUser.FirstName;
                    user.LastName = MyUser.LastName;
                    user.Email = MyUser.Email;
                    user.Password = GetMD5(MyUser.Password);
                    MyUser.ImagePath = getImagePath(MyUser.PassportImage);
                    user.PassportImage = MyUser.ImagePath;
                    user.DateOfBirth = MyUser.DateOfBirth;
                    user.Phone = MyUser.Phone;
                    HttpResponseMessage webResponse = webClient.PostAsJsonAsync("http://localhost:64732/api/Users", user).Result;
                    if (webResponse.IsSuccessStatusCode)
                    {
                        MyUser.PassportImage.SaveAs(Server.MapPath(MyUser.ImagePath));
                        ViewBag.Message = "Registration Succesfull!!,Please proceed to Login..";
                        logger.Info("Registration Succesfull for " + user.FirstName);
                        return View();
                    }                                         
                }
                else
                {
                    return View(MyUser);
                }
            }
            catch (Exception ex)
            {
               
                logger.Error(ex.Message, ex);

            }
            ViewBag.Message = "There was a error for registration..Please try again after some time!!";
            return View();
        }
        [Authorize]
        public ActionResult Dashboard()
        {                   
                return View();           
        }
        
        public ActionResult Logout()
        {
            Session.Clear();//remove session       
            Session.RemoveAll();
            Session.Abandon();
            Response.AddHeader("Cache-control", "no-store, must-revalidate, private, no-cache");
            Response.AddHeader("Pragma", "no-cache");
            Response.AddHeader("Expires", "0");
            Response.AppendToLog("window.location.reload();");
            FormsAuthentication.SignOut();
         
            return RedirectToAction("Login");
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        public string getImagePath(HttpPostedFileBase file)
        {
            try
            {
                string FileName = Path.GetFileNameWithoutExtension(file.FileName);
                //To Get File Extension  
                string FileExtension = Path.GetExtension(file.FileName);
                //Add Current Date To Attached File Name  
                FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + FileName.Trim() + FileExtension;
                //Get Upload path from Web.Config file AppSettings.  
                string UploadPath = "~/ImageUploads/UserImage/";
                //Its Create complete path to store in server.  
                String ipath = UploadPath + FileName;
                //To copy and save file into server.  
              //  file.SaveAs(Server.MapPath(ipath));
                return ipath;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }


    }
}
