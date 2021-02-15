using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PMS.BAL.Interfaces;
using PMS.Common.Models;
using ProductsApi;

namespace ProductsApi.Controllers
{
    public class UsersController : ApiController
    {

        private readonly IUser _userManager;

        public UsersController(IUser userManager)
        {
            _userManager = userManager;
        }

        // GET: api/Users
        public HttpResponseMessage GettblUsers()
        {
            var users = _userManager.getAllUsers();
            if (users.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // GET: api/Users/5
        public HttpResponseMessage GettblUser(string id)
        {
            if (id != null)
            {
                var user = _userManager.getUserByID(id);
                if (user.LastName!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, user);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // PUT: api/Users/5
      
        public HttpResponseMessage PuttblUser( User model)
        {
            if (_userManager.updateUser(model))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
        }

        // POST: api/Users
      
        public HttpResponseMessage PosttblUser(User model)
        {
            if (_userManager.createUser(model))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
        }

        // DELETE: api/Users/5
      
        public HttpResponseMessage DeletetblUser(string id)
        {
            if (_userManager.deleteUser(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
        }

     
    }
}