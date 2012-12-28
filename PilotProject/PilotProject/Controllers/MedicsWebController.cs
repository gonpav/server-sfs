using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PilotProject.Services;
using PilotProject.Models;

namespace PilotProject.Controllers
{
    public class MedicsWebController : ApiController
    {
        private MedicsService medicsService = new MedicsService();
        // GET api/medicsweb
        public IEnumerable<Medic> Get()
        {
            return medicsService.GetAll();
        }

        // GET api/medicsweb/5
        public Medic Get(int id)
        {
            Medic medic = medicsService.GetById(id);
            if (medic == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return medic;
        }

        // POST api/medicsweb
        public void Post([FromBody]Medic value)
        {
        }

        // PUT api/medicsweb/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/medicsweb/5
        public void Delete(int id)
        {
        }
    }
}
