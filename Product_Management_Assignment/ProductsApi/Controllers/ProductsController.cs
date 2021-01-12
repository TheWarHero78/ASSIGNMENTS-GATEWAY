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
using ProductsApi;

namespace ProductsApi.Controllers
{
    public class ProductsController : ApiController
    {
        private DBProductsEntities db = new DBProductsEntities();

        // GET: api/Products
        public IHttpActionResult GettblProducts(string[] ID, string search, string SortColumn,string IconClass,int PageNo)
        {
            if (search == null)
            {
                search = "";
            }
            List<tblProduct> products = db.tblProducts.Where(temp => temp.ProductName.Contains(search) || temp.tblCategory.CategoryName.Contains(search)).ToList();
            /*Sorting*/
            
            if (SortColumn == "ProductID")
            {
                if (IconClass == "fa-sort-amount-asc")
                    products = products.OrderBy(temp => temp.ProductID).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductID).ToList();
            }
            else if (SortColumn == "ProductName")
            {
                if (IconClass == "fa-sort-amount-asc")
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();
            }
            else if (SortColumn == "Price")
            {
                if (IconClass == "fa-sort-amount-asc")
                    products = products.OrderBy(temp => temp.Price).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Price).ToList();
            }
            else if (SortColumn == "Quantity")
            {
                if (IconClass == "fa-sort-amount-asc")
                    products = products.OrderBy(temp => temp.Quantity).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Quantity).ToList();
            }
            else if (SortColumn == "ShortDescription")
            {
                if (IconClass == "fa-sort-amount-asc")
                    products = products.OrderBy(temp => temp.ShortDescription).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ShortDescription).ToList();
            }
            else if (SortColumn == "Category")
            {
                if (IconClass == "fa-sort-amount-asc")
                    products = products.OrderBy(temp => temp.tblCategory.CategoryName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.tblCategory.CategoryName).ToList();
            }
           


            return Ok(products);
        }

        // GET: api/Products/5
        [ResponseType(typeof(tblProduct))]
        public IHttpActionResult GettblProduct(string id)
        {
            tblProduct tblProduct = db.tblProducts.Find(id);
            
            if (tblProduct == null)
            {
                return NotFound();
            }

            return Ok(tblProduct);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblProduct(string id, tblProduct tblProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblProduct.ProductID)
            {
                return BadRequest();
            }

            db.Entry(tblProduct).State = EntityState.Modified;

            try
            {
              //  db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(tblProduct))]
        public IHttpActionResult PosttblProduct(tblProduct tblProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int count = db.tblProducts.Count();
            tblProduct.ProductID = "PR00" + (count + 1);
            db.tblProducts.Add(tblProduct);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblProductExists(tblProduct.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblProduct.ProductID }, tblProduct);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(tblProduct))]
        public IHttpActionResult DeletetblProduct(string id)
        {
            tblProduct tblProduct = db.tblProducts.Find(id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            db.tblProducts.Remove(tblProduct);
           db.SaveChanges();

            return Ok(tblProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblProductExists(string id)
        {
            return db.tblProducts.Count(e => e.ProductID == id) > 0;
        }
    }
}