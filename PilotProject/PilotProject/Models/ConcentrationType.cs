using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class ConcentrationType
    {
        public int concentrationTypeID { get; set; }
        public string name { get; set; }

        public virtual ICollection<MedicationType> medicationTypes { get; set; }
    }
}