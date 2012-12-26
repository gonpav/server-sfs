using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PilotProject.Models
{
    public class SFFContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<PilotProject.Models.SFFContext>());

        public DbSet<PilotProject.Models.ParameterBase> ParameterBases { get; set; }

        public DbSet<PilotProject.Models.ParameterBaseType> ParameterBaseTypes { get; set; }

        public DbSet<PilotProject.Models.Activity> Activities { get; set; }

        public DbSet<PilotProject.Models.ActivityType> ActivityTypes { get; set; }

        public DbSet<PilotProject.Models.Client> Clients { get; set; }

        public DbSet<PilotProject.Models.ConcentrationType> ConcentrationTypes { get; set; }

        public DbSet<PilotProject.Models.Disease> Diseases { get; set; }

        public DbSet<PilotProject.Models.DoseMeasureType> DoseMeasureTypes { get; set; }

        public DbSet<PilotProject.Models.DosePerType> DosePerTypes { get; set; }

        public DbSet<PilotProject.Models.Flowsheet> Flowsheets { get; set; }

        public DbSet<PilotProject.Models.Fluid> Fluids { get; set; }

        public DbSet<PilotProject.Models.FluidType> FluidTypes { get; set; }

        public DbSet<PilotProject.Models.Hospitalization> Hospitalizations { get; set; }

        public DbSet<PilotProject.Models.LogRecord> LogRecords { get; set; }

        public DbSet<PilotProject.Models.Medic> Medics { get; set; }

        public DbSet<PilotProject.Models.Medication> Medications { get; set; }

        public DbSet<PilotProject.Models.MedicationType> MedicationTypes { get; set; }

        public DbSet<PilotProject.Models.ParameterRangeTypeValue> ParameterRangeTypeValues { get; set; }

        public DbSet<PilotProject.Models.ParameterSelectionTypeValue> ParameterSelectionTypeValues { get; set; }

        public DbSet<PilotProject.Models.ParameterTextTypeValue> ParameterTextTypeValues { get; set; }

        public DbSet<PilotProject.Models.ParameterType> ParameterTypes { get; set; }

        public DbSet<PilotProject.Models.ParameterValue> ParameterValues { get; set; }

        public DbSet<PilotProject.Models.ParameterValueType> ParameterValueTypes { get; set; }

        public DbSet<PilotProject.Models.Patient> Patients { get; set; }

        public DbSet<PilotProject.Models.Procedure> Procedures { get; set; }

        public DbSet<PilotProject.Models.ProcedureType> ProcedureTypes { get; set; }

        public DbSet<PilotProject.Models.RouteType> RouteTypes { get; set; }

        public DbSet<PilotProject.Models.SexType> SexTypes { get; set; }

        public DbSet<PilotProject.Models.Species> Species { get; set; }

        public DbSet<PilotProject.Models.TreatmentLog> TreatmentLogs { get; set; }

        public DbSet<PilotProject.Models.TreatmentValueStatusType> TreatmentValueStatusTypes { get; set; }

        public DbSet<PilotProject.Models.MedicType> MedicTypes { get; set; }
    }
}