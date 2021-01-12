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
    public class UsersController : ApiController
    {
        private DBProductsEntities db = new DBProductsEntities();

        // GET: api/Users
        public IQueryable<tblUser> GettblUsers()
        {
            return db.tblUsers;
        }

        // GET: api/Users/5
        [ResponseType(typeof(tblUser))]
        public IHttpActionResult GettblUser(string id)
        {
            tblUser tblUser = db.tblUsers.Where(e => e.Email== id).FirstOrDefault();
            if (tblUser == null)
            {
                return NotFound();
            }

            return Ok(tblUser);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblUser(string id, tblUser tblUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblUser.UserID)
            {
                return BadRequest();
            }

            db.Entry(tblUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblUserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(tblUser))]
        public IHttpActionResult PosttblUser(tblUser tblUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int count = db.tblUsers.Count() + 1;
            tblUser.UserID = "U00" + count;         
   

            db.tblUsers.Add(tblUser);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblUserExists(tblUser.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblUser.UserID }, tblUser);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(tblUser))]
        public IHttpActionResult DeletetblUser(string id)
        {
            tblUser tblUser = db.tblUsers.Find(id);
            if (tblUser == null)
            {
                return NotFound();
            }

            db.tblUsers.Remove(tblUser);
            db.SaveChanges();

            return Ok(tblUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblUserExists(string id)
        {
            return db.tblUsers.Count(e => e.UserID == id) > 0;
        }
    }
}