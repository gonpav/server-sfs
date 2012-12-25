using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class Client
    {
        public int clientID { get; set; }
        public string customField { get; set; }
        public string externalId { get; set; }
        public string homePhone { get; set; }
        public string nameFirst { get; set; }
        public string nameLast { get; set; }
        public string workPhone { get; set; }

        public virtual ICollection<Patient> pets { get; set; }
    }
}