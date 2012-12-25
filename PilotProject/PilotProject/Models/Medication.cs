using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class Medication : ParameterBase
    {
        public int medicationID { get; set; }
        public double concentration { get; set; }
        public string concentrationTypeAsString { get; set; }
        public int displayOption { get; set; }
        public double dose { get; set; }
        public string doseMeasureAsString { get; set; }
        public string dosePerTypeAsString { get; set; }
        public int pricingTypeOption { get; set; }
        public string routeTypeAsString { get; set; }
        public double totalDose { get; set; }
        public double totalDoseAlternative { get; set; }
    }
}