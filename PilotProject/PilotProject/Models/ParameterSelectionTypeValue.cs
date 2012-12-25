using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class ParameterSelectionTypeValue
    {
        public int parameterSelectionTypeValueID { get; set; }
        public bool isPlannedValue { get; set; }
        public string nameFull { get; set; }
        public string nameShort { get; set; }
        public string parameterTypeType_Id { get; set; }

        public int parameterTypeID { get; set; }
        public ParameterType parameterType { get; set; }
    }
}