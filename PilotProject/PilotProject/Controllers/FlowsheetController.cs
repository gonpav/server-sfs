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
    public class FlowsheetController : ApiController
    {
        private SFFContext db = new SFFContext();

        // GET api/Flowsheet
        public IEnumerable<Flowsheet> GetFlowsheets()
        {
            var flowsheets = db.Flowsheets.Include(f => f.Medic);
            return flowsheets.AsEnumerable();
        }

        // GET api/Flowsheet/5
        public Flowsheet GetFlowsheet(int id)
        {
            Flowsheet flowsheet = db.Flowsheets.Find(id);
            if (flowsheet == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return flowsheet;
        }

        // PUT api/Flowsheet/5
        public HttpResponseMessage PutFlowsheet(int id, Flowsheet flowsheet)
        {
            if (ModelState.IsValid && id == flowsheet.Id)
            {
                db.Entry(flowsheet).State = EntityState.Modified;

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

        // POST api/Flowsheet
        public HttpResponseMessage PostFlowsheet(Flowsheet flowsheet)
        {
            if (ModelState.IsValid)
            {
                db.Flowsheets.Add(flowsheet);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, flowsheet);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = flowsheet.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Flowsheet/5
        public HttpResponseMessage DeleteFlowsheet(int id)
        {
            Flowsheet flowsheet = db.Flowsheets.Find(id);
            if (flowsheet == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Flowsheets.Remove(flowsheet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, flowsheet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}