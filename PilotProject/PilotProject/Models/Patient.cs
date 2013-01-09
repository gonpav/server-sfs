using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PilotProject.Models
{
    [DisplayColumn("name")]
    public class Patient
    {
        public int patientID { get; set; }
        public DateTime? birthday { get; set; }
        public string breed { get; set; }
        public string customField { get; set; }
        public string externalId { get; set; }
        public string name { get; set; }
        public string visualfeatures { get; set; }

        //public int hospitalizationID { get; set; }
        //public virtual Hospitalization hospitalization { get; set; }
        public virtual ICollection<Hospitalization> hospitalizations { get; set; }

        public int clientID { get; set; }
        public virtual Client owner { get; set; }

        public int speciesID { get; set; }
        public virtual Species pet { get; set; }

        public int sexTypeID { get; set; }
        public virtual SexType sex { get; set; }
    }
}