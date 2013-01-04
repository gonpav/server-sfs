using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class ParameterRangeTypeValue : ParameterValueType
    {
        public int parameterRangeTypeValueID { get; set; }
        public double defaultValue { get; set; }
        public string extraMax { get; set; }
        public string extraMin { get; set; }
        public bool isDouble { get; set; }
        public double max { get; set; }
        public double min { get; set; }
        public string measurement { get; set; }
        public string parameterTypeType_Id { get; set; }

        public int parameterTypeID { get; set; }
    }
}