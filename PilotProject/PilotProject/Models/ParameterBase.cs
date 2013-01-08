using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class ParameterBase
    {
        public int parameterBaseID { get; set; }
        public string comment { get; set; }
        public string customField { get; set; }
        public bool discontinued { get; set; }
        public int frequency { get; set; }
        public int inHospParameterID { get; set; }
        public int planningStartHour { get; set; }
        public decimal price { get; set; }
        public bool visible { get; set; }

        public int parameterBaseTypeID { get; set; }
        public virtual ParameterBaseType parameterBaseType { get; set; }

        //public int parameterTypeID { get; set; }
        //public virtual ParameterType parameterType { get; set; }

        public int flowsheetID { get; set; }
        public virtual Flowsheet flowsheet { get; set; }

        public virtual ICollection<ParameterValue> values { get; set; }
    }
}