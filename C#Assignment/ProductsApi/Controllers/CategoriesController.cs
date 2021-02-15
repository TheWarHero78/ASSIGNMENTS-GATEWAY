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
    public class CategoriesController : ApiController
    {
        private readonly ICategory _categoryManager;

        public CategoriesController(ICategory categoryManager)
        {
            _categoryManager = categoryManager;
        }
        // GET: api/Categories
        public HttpResponseMessage GettblCategories()
        {
           var categories= _categoryManager.getAllCategory();
            if (categories.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, categories);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // GET: api/Categories/5
       
        public HttpResponseMessage GettblCategory(string id)
        {

            var category = _categoryManager.getCategoryByID(id);
            
           
            if (category.CategoryName == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, category);
        }

        // PUT: api/Categories/5
    
        public HttpResponseMessage PuttblCategory(string id, Category model)
        {
            if ( model.CategoryID!=null)
            {

                if (_categoryManager.updateCategory(model))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST: api/Categories
       
        public HttpResponseMessage PosttblCategory(Category model)
        {


            if (model.CategoryID!=null)
            {

                if (_categoryManager.createCategory(model))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE: api/Categories/5
       
        public HttpResponseMessage DeletetblCategory(string id)
        {
            if (id != null)
            {

                if (_categoryManager.deleteCategory(id))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

     

      
    }
}