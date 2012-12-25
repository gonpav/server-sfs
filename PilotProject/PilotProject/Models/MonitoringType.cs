using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class MonitoringType : ParameterBaseType
    {
        public int monitoringTypeID { get; set; }
        public string defaultMaxCriticalValueAsString { get; set; }
        public string defaultMinCriticalValueAsString { get; set; }
    }
}