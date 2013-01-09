using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PilotProject.Models;
using PilotProject.Services;

namespace PilotProject.Controllers
{
    public class HospitalizationsWebController : ApiController
    {
        private HospitalizationsService hospitalizationsService = new HospitalizationsService();
        // GET api/hospitalizationsweb
        public IEnumerable<Hospitalization> Get()
        {
            return hospitalizationsService.GetAll();
            //return hospitalizations.AsEnumerable();
        }

        // GET api/hospitalizationsweb/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/hospitalizationsweb
        // POST api/Default2
        public HttpResponseMessage Post(Hospitalization hospitalization)
        {
            string hosp = Request.Content.ReadAsStringAsync().Result;
            //Request.Content.
            Hospitalization result = Newtonsoft.Json.JsonConvert.DeserializeObject<Hospitalization>(hosp);
            if (ModelState.IsValid)
            {
                //db.Medics.Add(hospitalization);
                //db.SaveChanges();
                hospitalizationsService.Add(hospitalization);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, hospitalization);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = hospitalization.hospitalizationID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/hospitalizationsweb/5
        public void Put(int id, [FromBody]string value)
        {
            Hospitalization result = Newtonsoft.Json.JsonConvert.DeserializeObject<Hospitalization>(value);
            if (value != null)
            {
                return;
            }
            //return Request.CreateResponse(HttpStatusCode.Created, value);
        }

        // DELETE api/hospitalizationsweb/5
        public void Delete(int id)
        {
        }
    }
}
