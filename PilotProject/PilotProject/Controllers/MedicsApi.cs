using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using PilotProject.Models;

namespace PilotProject
{
	public class MedicsApi : ApiController 
	{
		private readonly IMedicRepository medicRepository;

		// If you are using Dependency Injection, you can delete the following constructor
		public MedicsApi () : this(new MedicRepository()) 
		{
		}

		public MedicsApi (IMedicRepository medicRepository) 
		{
			this.medicRepository = medicRepository;
		}

		public IEnumerable<Medic> GetAll()
		{
			return this.medicRepository.All.ToList();
		}

		public Medic Get(int id)
		{
			var Medic = this.medicRepository.Find(id);
			if (Medic == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Medic;
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
                var validationResults = this.ModelState.SelectMany(m => m.Value.Errors.Select(x => x.ErrorMessage + "(Property: " + m.Key + ")" ));
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.BadRequest, validationResults));
            }
		}

		public HttpResponseMessage Put(int id, Medic medic)
		{
			if (ModelState.IsValid && id == medic.medicID)
            {
                this.medicRepository.InsertOrUpdate(medic);
                this.medicRepository.Save();             

                return Request.CreateResponse(HttpStatusCode.OK, medic);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
		}

		public HttpResponseMessage Delete(int id)
		{
			var medic = this.medicRepository.Find(id);
            if (medic == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this.medicRepository.Delete(id);
            this.medicRepository.Save();

            return Request.CreateResponse(HttpStatusCode.NoContent, medic);
		}
	}
}

