namespace PilotProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParameterBases",
                c => new
                    {
                        parameterBaseID = c.Int(nullable: false, identity: true),
                        comment = c.String(),
                        customField = c.String(),
                        discontinued = c.Boolean(nullable: false),
                        frequency = c.Int(nullable: false),
                        inHospParameterID = c.Int(nullable: false),
                        planningStartHour = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        visible = c.Boolean(nullable: false),
                        activityID = c.Int(),
                        fluidID = c.Int(),
                        deH2O = c.Double(),
                        displayOption = c.Int(),
                        duration = c.Int(),
                        fluidDeficit = c.Double(),
                        hourRate = c.Double(),
                        maintenance = c.Double(),
                        medicationID = c.Int(),
                        concentration = c.Double(),
                        concentrationTypeAsString = c.String(),
                        displayOption1 = c.Int(),
                        dose = c.Double(),
                        doseMeasureAsString = c.String(),
                        dosePerTypeAsString = c.String(),
                        pricingTypeOption = c.Int(),
                        routeTypeAsString = c.String(),
                        totalDose = c.Double(),
                        totalDoseAlternative = c.Double(),
                        monitoringID = c.Int(),
                        maxCriticalValueAsString = c.String(),
                        minCriticalValueAsString = c.String(),
                        procedureID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ParameterBaseType_parameterBaseTypeID = c.Int(),
                        Flowsheet_flowsheetID = c.Int(),
                        ParameterType_parameterTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.parameterBaseID)
                .ForeignKey("dbo.ParameterBaseTypes", t => t.ParameterBaseType_parameterBaseTypeID)
                .ForeignKey("dbo.Flowsheets", t => t.Flowsheet_flowsheetID)
                .ForeignKey("dbo.ParameterTypes", t => t.ParameterType_parameterTypeID)
                .Index(t => t.ParameterBaseType_parameterBaseTypeID)
                .Index(t => t.Flowsheet_flowsheetID)
                .Index(t => t.ParameterType_parameterTypeID);
            
            CreateTable(
                "dbo.ParameterBaseTypes",
                c => new
                    {
                        parameterBaseTypeID = c.Int(nullable: false, identity: true),
                        canHaveCriticalValue = c.Boolean(nullable: false),
                        canHavePrice = c.Boolean(nullable: false),
                        defaultFrequency = c.Int(nullable: false),
                        defaultPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        defaultVisible = c.Boolean(nullable: false),
                        displayOrder = c.Int(nullable: false),
                        isDefault = c.Boolean(nullable: false),
                        nameFull = c.String(),
                        nameShort = c.String(),
                        parameterValueTypeID = c.Int(nullable: false),
                        activityTypeID = c.Int(),
                        fluidTypeID = c.Int(),
                        medicationTypeID = c.Int(),
                        defaultConcentration = c.Double(),
                        concentrationTypeID = c.Int(),
                        doseMeasureType = c.Int(),
                        dosePerType = c.Int(),
                        routeType = c.Int(),
                        monitoringTypeID = c.Int(),
                        defaultMaxCriticalValueAsString = c.String(),
                        defaultMinCriticalValueAsString = c.String(),
                        procedureTypeID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        defaultDoseMeasureType_doseMeasureTypeID = c.Int(),
                        defaultDosePerType_dosePerTypeID = c.Int(),
                        defaultRouteType_routeTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.parameterBaseTypeID)
                .ForeignKey("dbo.ParameterValueTypes", t => t.parameterValueTypeID, cascadeDelete: true)
                .ForeignKey("dbo.ConcentrationTypes", t => t.concentrationTypeID, cascadeDelete: true)
                .ForeignKey("dbo.DoseMeasureTypes", t => t.defaultDoseMeasureType_doseMeasureTypeID)
                .ForeignKey("dbo.DosePerTypes", t => t.defaultDosePerType_dosePerTypeID)
                .ForeignKey("dbo.RouteTypes", t => t.defaultRouteType_routeTypeID)
                .Index(t => t.parameterValueTypeID)
                .Index(t => t.concentrationTypeID)
                .Index(t => t.defaultDoseMeasureType_doseMeasureTypeID)
                .Index(t => t.defaultDosePerType_dosePerTypeID)
                .Index(t => t.defaultRouteType_routeTypeID);
            
            CreateTable(
                "dbo.ParameterValueTypes",
                c => new
                    {
                        parameterValueTypeID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.parameterValueTypeID);
            
            CreateTable(
                "dbo.ConcentrationTypes",
                c => new
                    {
                        concentrationTypeID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.concentrationTypeID);
            
            CreateTable(
                "dbo.DoseMeasureTypes",
                c => new
                    {
                        doseMeasureTypeID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.doseMeasureTypeID);
            
            CreateTable(
                "dbo.DosePerTypes",
                c => new
                    {
                        dosePerTypeID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.dosePerTypeID);
            
            CreateTable(
                "dbo.RouteTypes",
                c => new
                    {
                        routeTypeID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.routeTypeID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        clientID = c.Int(nullable: false, identity: true),
                        customField = c.String(),
                        externalId = c.String(),
                        homePhone = c.String(),
                        nameFirst = c.String(),
                        nameLast = c.String(),
                        workPhone = c.String(),
                    })
                .PrimaryKey(t => t.clientID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        patientID = c.Int(nullable: false, identity: true),
                        birthday = c.DateTime(nullable: false),
                        breed = c.String(),
                        customField = c.String(),
                        externalId = c.String(),
                        name = c.String(),
                        visualfeatures = c.String(),
                        clientID = c.Int(nullable: false),
                        speciesID = c.Int(nullable: false),
                        sexTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.patientID)
                .ForeignKey("dbo.Clients", t => t.clientID, cascadeDelete: true)
                .ForeignKey("dbo.Species", t => t.speciesID, cascadeDelete: true)
                .ForeignKey("dbo.SexTypes", t => t.sexTypeID, cascadeDelete: true)
                .Index(t => t.clientID)
                .Index(t => t.speciesID)
                .Index(t => t.sexTypeID);
            
            CreateTable(
                "dbo.Hospitalizations",
                c => new
                    {
                        hospitalizationID = c.Int(nullable: false, identity: true),
                        customField = c.String(),
                        dateCreated = c.DateTime(nullable: false),
                        deposit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        finished = c.Boolean(nullable: false),
                        isMetricUnitSystem = c.Boolean(nullable: false),
                        treatmentLogID = c.Int(nullable: false),
                        patientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.hospitalizationID)
                .ForeignKey("dbo.TreatmentLogs", t => t.treatmentLogID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.patientID, cascadeDelete: true)
                .Index(t => t.treatmentLogID)
                .Index(t => t.patientID);
            
            CreateTable(
                "dbo.TreatmentLogs",
                c => new
                    {
                        treatmentLogID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.treatmentLogID);
            
            CreateTable(
                "dbo.LogRecords",
                c => new
                    {
                        logRecordID = c.Int(nullable: false, identity: true),
                        dateCreated = c.DateTime(nullable: false),
                        type = c.Int(nullable: false),
                        value = c.String(),
                        treatmentLogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.logRecordID)
                .ForeignKey("dbo.TreatmentLogs", t => t.treatmentLogID, cascadeDelete: true)
                .Index(t => t.treatmentLogID);
            
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        diseaseID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.diseaseID);
            
            CreateTable(
                "dbo.Flowsheets",
                c => new
                    {
                        flowsheetID = c.Int(nullable: false, identity: true),
                        customField = c.String(),
                        durationHours = c.Int(nullable: false),
                        startHour = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        medicID = c.Int(nullable: false),
                        hospitalizationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.flowsheetID)
                .ForeignKey("dbo.Medics", t => t.medicID, cascadeDelete: true)
                .ForeignKey("dbo.Hospitalizations", t => t.hospitalizationID, cascadeDelete: true)
                .Index(t => t.medicID)
                .Index(t => t.hospitalizationID);
            
            CreateTable(
                "dbo.Medics",
                c => new
                    {
                        medicID = c.Int(nullable: false, identity: true),
                        customField = c.String(),
                        nameFull = c.String(),
                        nameShort = c.String(),
                        medicTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.medicID)
                .ForeignKey("dbo.MedicTypes", t => t.medicTypeID, cascadeDelete: true)
                .Index(t => t.medicTypeID);
            
            CreateTable(
                "dbo.MedicTypes",
                c => new
                    {
                        medicTypeID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.medicTypeID);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        speciesID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.speciesID);
            
            CreateTable(
                "dbo.SexTypes",
                c => new
                    {
                        sexTypeID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.sexTypeID);
            
            CreateTable(
                "dbo.ParameterRangeTypeValues",
                c => new
                    {
                        parameterRangeTypeValueID = c.Int(nullable: false, identity: true),
                        defaultValue = c.Double(nullable: false),
                        extraMax = c.String(),
                        extraMin = c.String(),
                        isDouble = c.Boolean(nullable: false),
                        max = c.Double(nullable: false),
                        min = c.Double(nullable: false),
                        measurement = c.String(),
                        parameterTypeType_Id = c.String(),
                        parameterTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.parameterRangeTypeValueID)
                .ForeignKey("dbo.ParameterTypes", t => t.parameterTypeID, cascadeDelete: true)
                .Index(t => t.parameterTypeID);
            
            CreateTable(
                "dbo.ParameterTypes",
                c => new
                    {
                        parameterTypeID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.parameterTypeID);
            
            CreateTable(
                "dbo.ParameterSelectionTypeValues",
                c => new
                    {
                        parameterSelectionTypeValueID = c.Int(nullable: false, identity: true),
                        isPlannedValue = c.Boolean(nullable: false),
                        nameFull = c.String(),
                        nameShort = c.String(),
                        parameterTypeType_Id = c.String(),
                        parameterTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.parameterSelectionTypeValueID)
                .ForeignKey("dbo.ParameterTypes", t => t.parameterTypeID, cascadeDelete: true)
                .Index(t => t.parameterTypeID);
            
            CreateTable(
                "dbo.ParameterTextTypeValues",
                c => new
                    {
                        parameterTextTypeValueID = c.Int(nullable: false, identity: true),
                        parameterTypeType_Id = c.String(),
                        parameterTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.parameterTextTypeValueID)
                .ForeignKey("dbo.ParameterTypes", t => t.parameterTypeID, cascadeDelete: true)
                .Index(t => t.parameterTypeID);
            
            CreateTable(
                "dbo.ParameterValues",
                c => new
                    {
                        parameterValueID = c.Int(nullable: false, identity: true),
                        currentValueAsString = c.String(),
                        hour = c.Int(nullable: false),
                        treatmentValueID = c.Int(nullable: false),
                        parameterBaseID = c.Int(nullable: false),
                        treatmentValueStatusType = c.Int(nullable: false),
                        status_treatmentValueStatusTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.parameterValueID)
                .ForeignKey("dbo.ParameterBases", t => t.parameterBaseID, cascadeDelete: true)
                .ForeignKey("dbo.TreatmentValueStatusTypes", t => t.status_treatmentValueStatusTypeID)
                .Index(t => t.parameterBaseID)
                .Index(t => t.status_treatmentValueStatusTypeID);
            
            CreateTable(
                "dbo.TreatmentValueStatusTypes",
                c => new
                    {
                        treatmentValueStatusTypeID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.treatmentValueStatusTypeID);
            
            CreateTable(
                "dbo.DiseaseHospitalizations",
                c => new
                    {
                        Disease_diseaseID = c.Int(nullable: false),
                        Hospitalization_hospitalizationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Disease_diseaseID, t.Hospitalization_hospitalizationID })
                .ForeignKey("dbo.Diseases", t => t.Disease_diseaseID, cascadeDelete: true)
                .ForeignKey("dbo.Hospitalizations", t => t.Hospitalization_hospitalizationID, cascadeDelete: true)
                .Index(t => t.Disease_diseaseID)
                .Index(t => t.Hospitalization_hospitalizationID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.DiseaseHospitalizations", new[] { "Hospitalization_hospitalizationID" });
            DropIndex("dbo.DiseaseHospitalizations", new[] { "Disease_diseaseID" });
            DropIndex("dbo.ParameterValues", new[] { "status_treatmentValueStatusTypeID" });
            DropIndex("dbo.ParameterValues", new[] { "parameterBaseID" });
            DropIndex("dbo.ParameterTextTypeValues", new[] { "parameterTypeID" });
            DropIndex("dbo.ParameterSelectionTypeValues", new[] { "parameterTypeID" });
            DropIndex("dbo.ParameterRangeTypeValues", new[] { "parameterTypeID" });
            DropIndex("dbo.Medics", new[] { "medicTypeID" });
            DropIndex("dbo.Flowsheets", new[] { "hospitalizationID" });
            DropIndex("dbo.Flowsheets", new[] { "medicID" });
            DropIndex("dbo.LogRecords", new[] { "treatmentLogID" });
            DropIndex("dbo.Hospitalizations", new[] { "patientID" });
            DropIndex("dbo.Hospitalizations", new[] { "treatmentLogID" });
            DropIndex("dbo.Patients", new[] { "sexTypeID" });
            DropIndex("dbo.Patients", new[] { "speciesID" });
            DropIndex("dbo.Patients", new[] { "clientID" });
            DropIndex("dbo.ParameterBaseTypes", new[] { "defaultRouteType_routeTypeID" });
            DropIndex("dbo.ParameterBaseTypes", new[] { "defaultDosePerType_dosePerTypeID" });
            DropIndex("dbo.ParameterBaseTypes", new[] { "defaultDoseMeasureType_doseMeasureTypeID" });
            DropIndex("dbo.ParameterBaseTypes", new[] { "concentrationTypeID" });
            DropIndex("dbo.ParameterBaseTypes", new[] { "parameterValueTypeID" });
            DropIndex("dbo.ParameterBases", new[] { "ParameterType_parameterTypeID" });
            DropIndex("dbo.ParameterBases", new[] { "Flowsheet_flowsheetID" });
            DropIndex("dbo.ParameterBases", new[] { "ParameterBaseType_parameterBaseTypeID" });
            DropForeignKey("dbo.DiseaseHospitalizations", "Hospitalization_hospitalizationID", "dbo.Hospitalizations");
            DropForeignKey("dbo.DiseaseHospitalizations", "Disease_diseaseID", "dbo.Diseases");
            DropForeignKey("dbo.ParameterValues", "status_treatmentValueStatusTypeID", "dbo.TreatmentValueStatusTypes");
            DropForeignKey("dbo.ParameterValues", "parameterBaseID", "dbo.ParameterBases");
            DropForeignKey("dbo.ParameterTextTypeValues", "parameterTypeID", "dbo.ParameterTypes");
            DropForeignKey("dbo.ParameterSelectionTypeValues", "parameterTypeID", "dbo.ParameterTypes");
            DropForeignKey("dbo.ParameterRangeTypeValues", "parameterTypeID", "dbo.ParameterTypes");
            DropForeignKey("dbo.Medics", "medicTypeID", "dbo.MedicTypes");
            DropForeignKey("dbo.Flowsheets", "hospitalizationID", "dbo.Hospitalizations");
            DropForeignKey("dbo.Flowsheets", "medicID", "dbo.Medics");
            DropForeignKey("dbo.LogRecords", "treatmentLogID", "dbo.TreatmentLogs");
            DropForeignKey("dbo.Hospitalizations", "patientID", "dbo.Patients");
            DropForeignKey("dbo.Hospitalizations", "treatmentLogID", "dbo.TreatmentLogs");
            DropForeignKey("dbo.Patients", "sexTypeID", "dbo.SexTypes");
            DropForeignKey("dbo.Patients", "speciesID", "dbo.Species");
            DropForeignKey("dbo.Patients", "clientID", "dbo.Clients");
            DropForeignKey("dbo.ParameterBaseTypes", "defaultRouteType_routeTypeID", "dbo.RouteTypes");
            DropForeignKey("dbo.ParameterBaseTypes", "defaultDosePerType_dosePerTypeID", "dbo.DosePerTypes");
            DropForeignKey("dbo.ParameterBaseTypes", "defaultDoseMeasureType_doseMeasureTypeID", "dbo.DoseMeasureTypes");
            DropForeignKey("dbo.ParameterBaseTypes", "concentrationTypeID", "dbo.ConcentrationTypes");
            DropForeignKey("dbo.ParameterBaseTypes", "parameterValueTypeID", "dbo.ParameterValueTypes");
            DropForeignKey("dbo.ParameterBases", "ParameterType_parameterTypeID", "dbo.ParameterTypes");
            DropForeignKey("dbo.ParameterBases", "Flowsheet_flowsheetID", "dbo.Flowsheets");
            DropForeignKey("dbo.ParameterBases", "ParameterBaseType_parameterBaseTypeID", "dbo.ParameterBaseTypes");
            DropTable("dbo.DiseaseHospitalizations");
            DropTable("dbo.TreatmentValueStatusTypes");
            DropTable("dbo.ParameterValues");
            DropTable("dbo.ParameterTextTypeValues");
            DropTable("dbo.ParameterSelectionTypeValues");
            DropTable("dbo.ParameterTypes");
            DropTable("dbo.ParameterRangeTypeValues");
            DropTable("dbo.SexTypes");
            DropTable("dbo.Species");
            DropTable("dbo.MedicTypes");
            DropTable("dbo.Medics");
            DropTable("dbo.Flowsheets");
            DropTable("dbo.Diseases");
            DropTable("dbo.LogRecords");
            DropTable("dbo.TreatmentLogs");
            DropTable("dbo.Hospitalizations");
            DropTable("dbo.Patients");
            DropTable("dbo.Clients");
            DropTable("dbo.RouteTypes");
            DropTable("dbo.DosePerTypes");
            DropTable("dbo.DoseMeasureTypes");
            DropTable("dbo.ConcentrationTypes");
            DropTable("dbo.ParameterValueTypes");
            DropTable("dbo.ParameterBaseTypes");
            DropTable("dbo.ParameterBases");
        }
    }
}
