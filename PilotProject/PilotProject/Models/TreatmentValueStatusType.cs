using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class TreatmentValueStatusType
    {
        public int treatmentValueStatusTypeID { get; set; }
        public string name { get; set; }

        public virtual ICollection<ParameterValue> treatmentValues { get; set; }
    }
}