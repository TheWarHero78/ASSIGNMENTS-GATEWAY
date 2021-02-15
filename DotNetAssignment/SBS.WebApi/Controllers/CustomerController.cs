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
    public class CustomerController : ApiController
    {
        private readonly ICustomer _customerManager;

        public CustomerController(ICustomer customerManager)
        {
            _customerManager = customerManager;
        }
        [HttpGet]
        [Route("api/Customers/getAllCustomer")]
        public HttpResponseMessage getAllCustomer()
        {
            List<CustomerViewModel> result = _customerManager.getAllCustomer();
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
        [Route("api/Customers/getCustomerByExID")]
        public HttpResponseMessage getCustomerByExID(string exID)
        {
           CustomerViewModel result = _customerManager.getCustomerByExID(exID);
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
        [Route("api/Customers/getAllCustomerByUser")]
        public HttpResponseMessage getAllCustomerByUser(string userExID)
        {
            CustomerViewModel result = _customerManager.getAllCustomerByUser(userExID);
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
        [Route("api/Customers/getCustomerUser")]
        public HttpResponseMessage getCustomerUser(string exID)
        {
            UserCustomerViewModel result = _customerManager.getCustomerUser(exID);
            if (result != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
        }
        [HttpPost]
        [Route("api/Customers/registerCustomer")]
        public HttpResponseMessage registerCustomer([FromBody]CustomerViewModel model)
        {
            bool result = _customerManager.registerCustomer(model);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
        }
        [HttpPut]
        [Route("api/Customers/updateCustomerDetails")]
        public HttpResponseMessage updateCustomerDetails([FromBody]CustomerViewModel model)
        {
            bool result = _customerManager.updateCustomerDetails(model);
            if (result)
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
