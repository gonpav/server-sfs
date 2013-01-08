using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PilotProject.Models;

namespace PilotProject.DAL
{
    public class SFSInitializer : DropCreateDatabaseAlways<SFSContext>
    {
        protected override void Seed(SFSContext context)
        {
            var clients = new List<Client>
            {
                new Client { customField = "", nameFirst = "Jack", nameLast = "Navarro" }
            };
            clients.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();

            var concentrationTypes = new List<ConcentrationType>
            {
                new ConcentrationType { name = "ml" },
                new ConcentrationType { name = "tab" },
                new ConcentrationType { name = "cap" }
            };
            concentrationTypes.ForEach(s => context.ConcentrationTypes.Add(s));
            context.SaveChanges();

            var diseases = new List<Disease>
            {
                new Disease { name = "Vomiting" },
                new Disease { name = "Diarrhea" },
                new Disease { name = "Seizure" },
                new Disease { name = "HBC" },
                new Disease { name = "CRF" },
                new Disease { name = "CHF" },
                new Disease { name = "DKA" },
                new Disease { name = "FLUTD" },
            };
            diseases.ForEach(s => context.Diseases.Add(s));
            context.SaveChanges();

            var dmTypes = new List<DoseMeasureType>
            {
                new DoseMeasureType { name = "mg" },
                new DoseMeasureType { name = "OjG" },
                new DoseMeasureType { name = "drop" },
            };

            dmTypes.ForEach(s => context.DoseMeasureTypes.Add(s));
            context.SaveChanges();

            var dosePerTypes = new List<DosePerType>
            {
                new DosePerType { name = "kg" },
                new DosePerType { name = "m2" },
                new DosePerType { name = "cat" },
                new DosePerType { name = "dog" },
                new DosePerType { name = "eye" },
            };

            dosePerTypes.ForEach(s => context.DosePerTypes.Add(s));
            context.SaveChanges();

            var medicTypes = new List<MedicType>
            {
                new MedicType { medicTypeID = 1, name = "Doctor" },
                new MedicType { medicTypeID = 2, name = "Technician" },
            };
            medicTypes.ForEach(s => context.MedicTypes.Add(s));
            context.SaveChanges();

            var medics = new List<Medic>
            {
                new Medic { nameFull = "Dr. Dre", nameShort = "Dr. Dre", medicTypeID = 1 }
            };
            medics.ForEach(s => context.Medics.Add(s));
            context.SaveChanges();

            var parameterType = new List<ParameterType> 
            { 
                new ParameterType { parameterTypeID = 1, name = "Monitoring" },
                new ParameterType { parameterTypeID = 2, name = "Activity" },
                new ParameterType { parameterTypeID = 3, name = "Fluid" },
                new ParameterType { parameterTypeID = 4, name = "Additive" },
                new ParameterType { parameterTypeID = 5, name = "CRI" },
                new ParameterType { parameterTypeID = 6, name = "Medication" },
                new ParameterType { parameterTypeID = 7, name = "Procedure" },
            };
            parameterType.ForEach(s => context.ParameterTypes.Add(s));
            context.SaveChanges();

            var treatmentValueStatusTypes = new List<TreatmentValueStatusType>
            {
                new TreatmentValueStatusType { name = "planned" },
                new TreatmentValueStatusType { name = "unplanned" },
            };
            treatmentValueStatusTypes.ForEach(s => context.TreatmentValueStatusTypes.Add(s));
            context.SaveChanges();

            var species = new List<Species>
            {
                new Species { name = "Canine" },
                new Species { name = "Feline" },
                new Species { name = "Lagomorph" },
            };
            species.ForEach(s => context.Species.Add(s));
            context.SaveChanges();

            var sexTypes = new List<SexType>
            {
                new SexType { name = "M" },
                new SexType { name = "MF" },
                new SexType { name = "MN" },
                new SexType { name = "FS" },
            };
            sexTypes.ForEach(s => context.SexTypes.Add(s));
            context.SaveChanges();

            var routeTypes = new List<RouteType>
            {
                new RouteType { name = "IV" },
                new RouteType { name = "SQ" },
                new RouteType { name = "IM" },
                new RouteType { name = "OD" },
                new RouteType { name = "OS" },
                new RouteType { name = "OU" },
                new RouteType { name = "PO" },
                new RouteType { name = "REC" },
                new RouteType { name = "TOP" },
            };
            routeTypes.ForEach(s => context.RouteTypes.Add(s));
            context.SaveChanges();

            var patients = new List<Patient>
            {
                new Patient { clientID = 1, sexTypeID = 3, birthday = DateTime.Now, breed = "spaniel", name = "Fluffy", visualfeatures = "calico", speciesID = 1 }
            };

            patients.ForEach(s => context.Patients.Add(s));
            context.SaveChanges();

            var treatmentLogs = new List<TreatmentLog> 
            {
                new TreatmentLog { treatmentLogID = 1 }
            };
            treatmentLogs.ForEach(s => context.TreatmentLogs.Add(s));
            context.SaveChanges();

            var hospitalizations = new List<Hospitalization>
            {
                new Hospitalization { isMetricUnitSystem = true, dateCreated = DateTime.Now, patientID = 1, treatmentLogID = 1 }
            };

            hospitalizations.ForEach(s => context.Hospitalizations.Add(s));
            context.SaveChanges();

            /*var parameterValueTypes = new List<ParameterValueType>
            {
                new ParameterValueType { name = "ParameterTextTypeValue" },
                new ParameterValueType { name = "ParameterSelectionTypeValue" },
                new ParameterValueType { name = "ParameterMedicIdTypeValue" },
                new ParameterValueType { name = "ParameterRangeTypeValue" }
            };
            parameterValueTypes.ForEach(s => context.ParameterValueTypes.Add(s));
            context.SaveChanges();*/

            var parameterRangeTypeValues = new List<ParameterRangeTypeValue>
            {
                new ParameterRangeTypeValue { min = 32.0, max = 43.0, name = "Temperature range",  parameterValueTypeID = 1}
            };
            parameterRangeTypeValues.ForEach(s => context.ParameterRangeTypeValues.Add(s));
            context.SaveChanges();

            var parameterSelectionTypeValues = new List<ParameterSelectionTypeValue>
            {
                new ParameterSelectionTypeValue { values = "Depressed,BAR,QAR,Comatouse", codes = "Depressed,BAR,QAR,Comatouse", name = "Attitude selection", parameterValueTypeID = 2 }
            };
            parameterSelectionTypeValues.ForEach(s => context.ParameterSelectionTypeValues.Add(s));
            context.SaveChanges();

            var parameterBaseTypes = new List<ParameterBaseType> 
            {
                new ParameterBaseType { parameterValueTypeID = 2, canHaveCriticalValue = true, canHavePrice = true, defaultFrequency = 6, defaultVisible = true, displayOrder = 0, isDefault = true, nameFull = "Attitude", nameShort = "Attitude" },
                new ParameterBaseType { parameterValueTypeID = 1, canHaveCriticalValue = true, canHavePrice = true, defaultFrequency = 6, defaultVisible = true, displayOrder = 0, isDefault = true, nameFull = "Temperature", nameShort = "Temperature" }
            };
            parameterBaseTypes.ForEach(s => context.ParameterBaseTypes.Add(s));
            context.SaveChanges();

            var parameterValues = new List<ParameterValue>
            {
                new ParameterValue { hour = 19, treatmentValueID = 1, currentValueAsString = "10.0" },
                new ParameterValue { hour = 19, treatmentValueID = 2, currentValueAsString = "20.0" }
            };

            //var parameterBases = new List<ParameterBase>
            //{
            //    new ParameterBase { frequency = 6, planningStartHour = 19, visible = true, parameterBaseTypeID = 1 }
            //};
            //parameterBases.ForEach(s => context.ParameterBases.Add(s));
            //context.SaveChanges();
        }
    }
}