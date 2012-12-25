using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class LogRecord
    {
        public int logRecordID { get; set; }
        public DateTime dateCreated { get; set; }
        public int type { get; set; }
        public string value { get; set; }

        public int treatmentLogID { get; set; }
        public virtual TreatmentLog log { get; set; }
    }
}