using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class DoseMeasureType
    {
        public int doseMeasureTypeID { get; set; }
        public string name { get; set; }

        public virtual ICollection<MedicationType> medicationTypes { get; set; }
    }
}