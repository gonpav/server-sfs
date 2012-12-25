using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class MedicationType : ParameterBaseType
    {
        public int medicationTypeID { get; set; }
        public double defaultConcentration { get; set; }

        public int concentrationTypeID { get; set; }
        public virtual ConcentrationType defaultConcentrationType { get; set; }

        public int doseMeasureType { get; set; }
        public virtual DoseMeasureType defaultDoseMeasureType { get; set; }

        public int dosePerType { get; set; }
        public virtual DosePerType defaultDosePerType { get; set; }

        public int routeType { get; set; }
        public virtual RouteType defaultRouteType { get; set; }
    }
}