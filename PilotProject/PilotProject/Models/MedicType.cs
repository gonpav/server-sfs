using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PilotProject.Models
{
    [DisplayColumn("name")]
    public class MedicType
    {
        public int medicTypeID { get; set; }
        public string name { get; set; }

        public virtual ICollection<Medic> medics { get; set; }
    }
}