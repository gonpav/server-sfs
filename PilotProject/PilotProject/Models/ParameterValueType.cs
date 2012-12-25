using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class ParameterValueType
    {
        public int parameterValueTypeID { get; set; }
        public string name { get; set; }

        public ICollection<ParameterBaseType> monitoringTypes { get; set; }
    }
}