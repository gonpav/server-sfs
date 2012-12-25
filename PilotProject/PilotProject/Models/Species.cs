using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class Species
    {
        public int speciesID { get; set; }
        public string name { get; set; }

        public virtual ICollection<Patient> patients { get; set; }
    }
}