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
    
    public partial class Medic
    {
        public Medic()
        {
            this.Flowsheet = new HashSet<Flowsheet>();
        }
    
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    
        public virtual ICollection<Flowsheet> Flowsheet { get; set; }
    }
}
