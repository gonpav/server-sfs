using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class Disease
    {
        public int diseaseID { get; set; }
        public string name { get; set; }

        public virtual ICollection<Hospitalization> hospitalizations { get; set; }
    }
}