using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class MedicType
    {
        public int medicTypeID { get; set; }
        public string name { get; set; }

        public virtual ICollection<Medic> medics { get; set; }
    }
}