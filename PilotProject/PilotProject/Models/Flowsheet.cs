using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class Flowsheet
    {
        public int flowsheetID { get; set; }
        public string customField { get; set; }
        public int durationHours { get; set; }
        public int startHour { get; set; }
        public DateTime date { get; set; }

        public int medicID { get; set; }
        public virtual Medic doctor { get; set; }

        public int hospitalizationID { get; set; }
        public virtual Hospitalization hospitalization { get; set; }

        public virtual ICollection<ParameterBase> parameters { get; set; }
    }
}