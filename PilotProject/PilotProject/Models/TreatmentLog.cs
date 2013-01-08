using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PilotProject.Models
{
    [DisplayColumn("treatmentLogID")]
    public class TreatmentLog
    {
        public int treatmentLogID { get; set; }
        public virtual ICollection<Hospitalization> hospitalizations { get; set; }
        public virtual ICollection<LogRecord> records { get; set; }
    }
}