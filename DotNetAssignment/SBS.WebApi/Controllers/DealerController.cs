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
    public class DealerController : ApiController
    {
        private readonly IDealer _dealerManager;

        public DealerController(IDealer dealerManager)
        {
            _dealerManager = dealerManager;
        }
        [HttpGet]
        [Route("api/Dealers/getAllDealers")]
        public HttpResponseMessage getAllDealers()
        {
            List<DealerViewModel> result = _dealerManager.getAllDealers();
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
        [Route("api/Dealers/getAllDealerName")]
        public HttpResponseMessage getAllDealerName()
        {
            List<DealerDropDown> result = _dealerManager.getAllDealerName();
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
        [Route("api/Dealers/getDealerByExID")]
        public HttpResponseMessage getDealerByExID(string exID)
        {
            DealerViewModel result = _dealerManager.getDealerByExID(exID);
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
        [Route("api/Dealers/getDealerByID")]
        public HttpResponseMessage getDealerByID(long ID)
        {
            DealerViewModel result = _dealerManager.getDealerByID(ID);
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
        [Route("api/Dealers/getAllDealerByUser")]
        public HttpResponseMessage getAllDealerByUser(string userExID)
        {
            DealerViewModel result = _dealerManager.getAllDealerByUser(userExID);
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
        [Route("api/Dealers/registerDealer")]
        public HttpResponseMessage registerDealer([FromBody]DealerViewModel model)
        {
            bool result = _dealerManager.registerDealer(model);
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
        [Route("api/Dealers/updateDealerDetails")]
        public HttpResponseMessage updateDealerDetails([FromBody]DealerViewModel model)
        {
            bool result = _dealerManager.updateDealerDetails(model);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
        }
        [HttpDelete]
        [Route("api/Dealers/deleteDealerDetails")]
        public HttpResponseMessage deleteDealerDetails(string exID)
        {
            bool result = _dealerManager.deleteDealerDetails(exID);
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

