using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using PilotProject.Models;

namespace PilotProject.Controllers
{
    public class Default1Controller : ApiController
    {
        private SFFContext db = new SFFContext();

        // GET api/Default1
        public IEnumerable<Medic> GetMedics()
        {
            var medics = db.Medics.Include(m => m.type);
            return medics.AsEnumerable();
        }

        // GET api/Default1/5
        public Medic GetMedic(int id)
        {
            Medic medic = db.Medics.Find(id);
            if (medic == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return medic;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutMedic(int id, Medic medic)
        {
            if (ModelState.IsValid && id == medic.medicID)
            {
                db.Entry(medic).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Default1
        public HttpResponseMessage PostMedic(Medic medic)
        {
            if (ModelState.IsValid)
            {
                db.Medics.Add(medic);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, medic);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = medic.medicID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteMedic(int id)
        {
            Medic medic = db.Medics.Find(id);
            if (medic == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Medics.Remove(medic);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, medic);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}