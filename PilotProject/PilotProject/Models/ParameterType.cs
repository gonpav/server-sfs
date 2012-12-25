using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class ParameterType
    {
        public int parameterTypeID { get; set; }
        public string name { get; set; }

        public virtual ICollection<ParameterBase> monitorings { get; set; }
        public virtual ICollection<ParameterRangeTypeValue> rangeTypeValues { get; set; }
        public virtual ICollection<ParameterSelectionTypeValue> selectionTypeValues { get; set; }
        public virtual ICollection<ParameterTextTypeValue> textTypeValues { get; set; }
    }
}