//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PilotProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Flowsheet
    {
        public int Id { get; set; }
        public string date { get; set; }
        public string durationHours { get; set; }
        public string startHour { get; set; }
        public int MedicId { get; set; }
    
        public virtual Medic Medic { get; set; }
    }
}