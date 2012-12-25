using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class Fluid : ParameterBase
    {
        public int fluidID { get; set; }
        public double deH2O { get; set; }
        public int displayOption { get; set; }
        public int duration { get; set; }
        public double fluidDeficit { get; set; }
        public double hourRate { get; set; }
        public double maintenance { get; set; }
    }
}