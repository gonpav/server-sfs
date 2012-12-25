using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class Medic
    {
        public int medicID { get; set; }
        public string customField { get; set; }
        public string nameFull { get; set; }
        public string nameShort { get; set; }

        public int medicTypeID { get; set; }
        public virtual MedicType type { get; set; }

        public virtual ICollection<Flowsheet> flowsheets { get; set; }
    }
}