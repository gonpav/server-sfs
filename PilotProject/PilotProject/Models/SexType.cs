using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class SexType
    {
        public int sexTypeID { get; set; }
        public string name { get; set; }

        public virtual ICollection<Patient> patients { get; set; }
    }
}