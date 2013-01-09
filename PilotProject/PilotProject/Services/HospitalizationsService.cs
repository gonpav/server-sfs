using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PilotProject.Models;
using PilotProject.DAL;

namespace PilotProject.Services
{
    public class HospitalizationsService
    {
        private UnitOfWork context = new UnitOfWork();

        public IEnumerable<Hospitalization> GetAll()
        {
            return context.HospitalizationRepository.Get();
        }

        public Hospitalization Add(Hospitalization hospitalization)
        {
            context.HospitalizationRepository.Insert(hospitalization);
            context.Save();
            return hospitalization;
        }
        /*
        // POST api/Hospitalizations
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

        public HttpResponseMessage Post(Medic medic)
        {
            if (ModelState.IsValid)
            {
                this.medicRepository.InsertOrUpdate(medic);
                this.medicRepository.Save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, medic);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = medic.medicID }));
                return response;
            }
            else
            {
                var validationResults = this.ModelState.SelectMany(m => m.Value.Errors.Select(x => x.ErrorMessage + "(Property: " + m.Key + ")"));
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.BadRequest, validationResults));
            }
        }*/
    }
}