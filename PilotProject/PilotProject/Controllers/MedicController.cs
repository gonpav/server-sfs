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

namespace PilotProject.Controllers
{
    public class MedicController : ApiController
    {
        private SFFContext db = new SFFContext();

        // GET api/Medic
        public IEnumerable<Medic> GetMedics()
        {
            return db.Medics.AsEnumerable();
        }

        // GET api/Medic/5
        public Medic GetMedic(int id)
        {
            Medic medic = db.Medics.Find(id);
            if (medic == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return medic;
        }

        // PUT api/Medic/5
        public HttpResponseMessage PutMedic(int id, Medic medic)
        {
            if (ModelState.IsValid && id == medic.Id)
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

        // POST api/Medic
        public HttpResponseMessage PostMedic(Medic medic)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Medics.Add(medic);
                    db.SaveChanges();
                    //Realtime notification
                    SignalR.MessageHub.SendMedicUpdate(medic);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Diagnostics.Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, medic);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = medic.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Medic/5
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