using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class ParameterValue
    {
        public int parameterValueID { get; set; }
        public string currentValueAsString { get; set; }
        public int hour { get; set; }
        public int treatmentValueID { get; set; }

        public int parameterBaseID { get; set; }
        public virtual ParameterBase parameter { get; set; }

        public int treatmentValueStatusType { get; set; }
        public virtual TreatmentValueStatusType status { get; set; }
    }
}