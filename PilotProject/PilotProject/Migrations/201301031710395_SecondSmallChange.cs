namespace PilotProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondSmallChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParameterBases", "ParameterBaseType_parameterBaseTypeID", "dbo.ParameterBaseTypes");
            DropForeignKey("dbo.ParameterBases", "Flowsheet_flowsheetID", "dbo.Flowsheets");
            DropForeignKey("dbo.ParameterBases", "ParameterType_parameterTypeID", "dbo.ParameterTypes");
            DropIndex("dbo.ParameterBases", new[] { "ParameterBaseType_parameterBaseTypeID" });
            DropIndex("dbo.ParameterBases", new[] { "Flowsheet_flowsheetID" });
            DropIndex("dbo.ParameterBases", new[] { "ParameterType_parameterTypeID" });
            RenameColumn(table: "dbo.ParameterBases", name: "ParameterBaseType_parameterBaseTypeID", newName: "parameterBaseTypeID");
            RenameColumn(table: "dbo.ParameterBases", name: "Flowsheet_flowsheetID", newName: "flowsheetID");
            RenameColumn(table: "dbo.ParameterBases", name: "ParameterType_parameterTypeID", newName: "parameterTypeID");
            AddForeignKey("dbo.ParameterBases", "parameterBaseTypeID", "dbo.ParameterBaseTypes", "parameterBaseTypeID", cascadeDelete: true);
            AddForeignKey("dbo.ParameterBases", "parameterTypeID", "dbo.ParameterTypes", "parameterTypeID", cascadeDelete: true);
            AddForeignKey("dbo.ParameterBases", "flowsheetID", "dbo.Flowsheets", "flowsheetID", cascadeDelete: true);
            CreateIndex("dbo.ParameterBases", "parameterBaseTypeID");
            CreateIndex("dbo.ParameterBases", "parameterTypeID");
            CreateIndex("dbo.ParameterBases", "flowsheetID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ParameterBases", new[] { "flowsheetID" });
            DropIndex("dbo.ParameterBases", new[] { "parameterTypeID" });
            DropIndex("dbo.ParameterBases", new[] { "parameterBaseTypeID" });
            DropForeignKey("dbo.ParameterBases", "flowsheetID", "dbo.Flowsheets");
            DropForeignKey("dbo.ParameterBases", "parameterTypeID", "dbo.ParameterTypes");
            DropForeignKey("dbo.ParameterBases", "parameterBaseTypeID", "dbo.ParameterBaseTypes");
            RenameColumn(table: "dbo.ParameterBases", name: "parameterTypeID", newName: "ParameterType_parameterTypeID");
            RenameColumn(table: "dbo.ParameterBases", name: "flowsheetID", newName: "Flowsheet_flowsheetID");
            RenameColumn(table: "dbo.ParameterBases", name: "parameterBaseTypeID", newName: "ParameterBaseType_parameterBaseTypeID");
            CreateIndex("dbo.ParameterBases", "ParameterType_parameterTypeID");
            CreateIndex("dbo.ParameterBases", "Flowsheet_flowsheetID");
            CreateIndex("dbo.ParameterBases", "ParameterBaseType_parameterBaseTypeID");
            AddForeignKey("dbo.ParameterBases", "ParameterType_parameterTypeID", "dbo.ParameterTypes", "parameterTypeID");
            AddForeignKey("dbo.ParameterBases", "Flowsheet_flowsheetID", "dbo.Flowsheets", "flowsheetID");
            AddForeignKey("dbo.ParameterBases", "ParameterBaseType_parameterBaseTypeID", "dbo.ParameterBaseTypes", "parameterBaseTypeID");
        }
    }
}
