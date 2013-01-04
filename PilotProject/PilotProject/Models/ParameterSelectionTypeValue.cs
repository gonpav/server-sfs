using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class ParameterSelectionTypeValue : ParameterValueType
    {
        public int parameterSelectionTypeValueID { get; set; }
        public bool isPlannedValue { get; set; }
        public string values { get; set; } //set of nameFull
        public string codes { get; set; } //set of nameShort
        public string parameterTypeType_Id { get; set; }

        public int parameterTypeID { get; set; }
        
    }
}