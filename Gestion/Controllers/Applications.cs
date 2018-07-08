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
using Gestion.Data;
using Gestion.Models;

namespace Gestion.Controllers
{
    public class Applications : ApiController
    {
        private GestionDbContext db = new GestionDbContext();

        // GET: api/Applications
        public IQueryable<Application> GetApplications()
        {
            return db.Applications.Where(x => !x.Deleted);
             
        }

        // GET: api/Applications/5
        [ResponseType(typeof(Application))]
        public IHttpActionResult GetApplication(int id)
        {
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }

        // PUT: api/Applications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplication(int id, Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != application.ID)
            {
                return BadRequest();
            }

            db.Entry(application).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
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

        // POST: api/Applications
        [ResponseType(typeof(Application))]
        public IHttpActionResult PostApplication(Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Applications.Add(application);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = application.ID }, application);
        }

        // DELETE: api/Applications/5
        [ResponseType(typeof(Application))]
        public IHttpActionResult DeleteApplication(int id)
        {
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return NotFound();
            }

            application.Deleted = true;
            application.DeletedAt = DateTime.Now;
            db.Entry(application).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Ok(application);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationExists(int id)
        {
            return db.Applications.Count(e => e.ID == id) > 0;
        }
    }
}