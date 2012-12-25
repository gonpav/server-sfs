using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class Monitoring : ParameterBase
    {
        public int monitoringID { get; set; }
        public string maxCriticalValueAsString { get; set; }
        public string minCriticalValueAsString { get; set; }
    }
}