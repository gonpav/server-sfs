using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class RouteType
    {
        public int routeTypeID { get; set; }
        public string name { get; set; }

        public virtual ICollection<MedicationType> medicationTypes { get; set; }
    }
}