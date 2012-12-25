using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class Hospitalization
    {
        public int hospitalizationID { get; set; }
        public string customField { get; set; }
        public DateTime dateCreated { get; set; }
        public decimal deposit { get; set; }
        public bool finished { get; set; }
        public bool isMetricUnitSystem { get; set; }

        public int treatmentLogID { get; set; }
        public virtual TreatmentLog log { get; set; }

        public int patientID { get; set; }
        public virtual Patient patient { get; set; }

        public virtual ICollection<Disease> diseases { get; set; }

        public virtual ICollection<Flowsheet> flowsheets { get; set; }
    }
}