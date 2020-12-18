using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using log4net;
using FinalAssignment.Models;
using System.Security.Cryptography;
using System.Text;

namespace FinalAssignment.Controllers
{


    public class UsersController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private UEntities db = new UEntities();


        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var f_password = GetMD5(password);
                    var data = db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                    if (data.Count() > 0)
                    {
                        //add session
                        Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                        Session["Email"] = data.FirstOrDefault().Email;
                        Session["idUser"] = data.FirstOrDefault().UserID;
                        logger.Info("Login Successfull for " + Session["FullName"]);
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        logger.Info("Login failed for " + email);
                        ViewBag.Message = "Login failed..Password or Email Wrong!!";
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "There was a error for login..Please try again after some time!!";
                logger.Error(ex.Message, ex);
            }
            return View();
        }
        public ActionResult Dashboard()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserMetaData MyUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                                  
                    User user = new User();
                    user.UserID = 0;
                    user.Age = MyUser.Age;
                    user.FirstName = MyUser.FirstName;
                    user.LastName = MyUser.LastName;
                    user.Email = MyUser.Email;
                    user.Password = GetMD5(MyUser.Password);
                    MyUser.ImagePath = getImagePath(MyUser.PassportImage);
                    user.PassportImage = MyUser.ImagePath;
                    user.DateOfJoining = MyUser.DateOfJoining;
                    user.Phone = MyUser.Phone;

                    db.Users.Add(user);
                    db.SaveChanges();
                    ViewBag.Message = "Registration Succesfull!!,Please proceed to Login..";
                    logger.Info("Registration Succesfull for " + user.FirstName);
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "There was a error for registration..Please try again after some time!!";
                logger.Error(ex.Message, ex);
            }
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
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
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                //Get Upload path from Web.Config file AppSettings.  
                string UploadPath = System.Configuration.ConfigurationManager.AppSettings["UserImagePath"].ToString();
                //Its Create complete path to store in server.  
                String ipath = UploadPath + FileName;
                //To copy and save file into server.  
                file.SaveAs(Server.MapPath(ipath));
                return ipath;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                throw new Exception(ex.Message,ex);               
            }
        }


    }
}
