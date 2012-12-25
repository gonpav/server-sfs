using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class ParameterBaseType
    {
        public int parameterBaseTypeID { get; set; }
        public bool canHaveCriticalValue { get; set; }
        public bool canHavePrice { get; set; }
        public int defaultFrequency { get; set; }
        public decimal defaultPrice { get; set; }
        public bool defaultVisible { get; set; }
        public int displayOrder { get; set; }
        public bool isDefault { get; set; }
        public string nameFull { get; set; }
        public string nameShort { get; set; }

        public int parameterValueTypeID { get; set; }
        public virtual ParameterValueType valueType { get; set; }

        public virtual ICollection<ParameterBase> parameters { get; set; }
    }
}