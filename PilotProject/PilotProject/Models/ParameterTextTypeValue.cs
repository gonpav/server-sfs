using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class ParameterTextTypeValue: ParameterValueType
    {
        public int parameterTextTypeValueID { get; set; }
        public string parameterTypeType_Id { get; set; }

        public int parameterTypeID { get; set; }
    }
}