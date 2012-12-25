using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class ParameterTextTypeValue
    {
        public int parameterTextTypeValueID { get; set; }
        public string parameterTypeType_Id { get; set; }

        public int parameterTypeID { get; set; }
        public virtual ParameterType parameterType { get; set; }
    }
}