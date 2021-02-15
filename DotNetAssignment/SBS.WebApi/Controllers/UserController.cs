using SBS.Business.Interfaces;
using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SBS.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUser _userManager;

        public UserController(IUser userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        [Route("api/Users/registerUser")]
        public HttpResponseMessage registerUser(UserViewModel model)
        {
            bool result = _userManager.createUser(model);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
        }
        [HttpPost]
        [Route("api/Users/checkUser")]
        public HttpResponseMessage checkUser(UserLoginViewModel model)
        {
            UserViewModel result = _userManager.validateUser(model);
            if (result.Email != null)
            {
              
                return Request.CreateResponse(HttpStatusCode.OK,  result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
        }
        [HttpGet]
        [Route("api/Users/getAllUser")]
        public HttpResponseMessage getAllUser()
        {
            List<UserViewModel> result = _userManager.getAllUsers();
            if (result != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
        }
        [HttpGet]
        [Route("api/Users/getAllUserDealer")]
        public HttpResponseMessage getAllUserDealer()
        {
            List<UserDealerDropDown> result = _userManager.getAllUserDealer();
            if (result != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
        }
    }
}
