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
    public class ProductsController : ApiController
    {
        private readonly IProduct _productManager;

        public ProductsController(IProduct productManager)
        {
            _productManager = productManager;
        }

        // GET: api/Products
        public HttpResponseMessage GettblProducts(string[] ID, string search, string SortColumn,string IconClass,int PageNo)
        {
            var product = _productManager.getProducts(ID, search, SortColumn, IconClass, PageNo);
            if(product.Count>0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // GET: api/Products/5
       
        public HttpResponseMessage GettblProduct(string id)
        {
            var product = _productManager.getProductByID(id);
            
            if (product.ProductName != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // PUT: api/Products/5
        
        public HttpResponseMessage PuttblProduct(Product model)
        {


            if (_productManager.updateProduct(model)){
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
        }

        // POST: api/Products
     
        public HttpResponseMessage PosttblProduct(Product model)
        {
            if (_productManager.createProduct(model))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }

        }

        // DELETE: api/Products/5
        public HttpResponseMessage DeletetblProduct(string id)
        {
            if (_productManager.deleteProduct(id))
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