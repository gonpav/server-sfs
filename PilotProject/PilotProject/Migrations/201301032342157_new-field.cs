namespace PilotProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfield : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParameterRangeTypeValues", "parameterTypeID", "dbo.ParameterTypes");
            DropForeignKey("dbo.ParameterSelectionTypeValues", "parameterTypeID", "dbo.ParameterTypes");
            DropForeignKey("dbo.ParameterTextTypeValues", "parameterTypeID", "dbo.ParameterTypes");
            DropIndex("dbo.ParameterRangeTypeValues", new[] { "parameterTypeID" });
            DropIndex("dbo.ParameterSelectionTypeValues", new[] { "parameterTypeID" });
            DropIndex("dbo.ParameterTextTypeValues", new[] { "parameterTypeID" });
            AddColumn("dbo.ParameterBaseTypes", "ParameterType_parameterTypeID", c => c.Int());
            AddColumn("dbo.ParameterValueTypes", "parameterRangeTypeValueID", c => c.Int());
            AddColumn("dbo.ParameterValueTypes", "defaultValue", c => c.Double());
            AddColumn("dbo.ParameterValueTypes", "extraMax", c => c.String());
            AddColumn("dbo.ParameterValueTypes", "extraMin", c => c.String());
            AddColumn("dbo.ParameterValueTypes", "isDouble", c => c.Boolean());
            AddColumn("dbo.ParameterValueTypes", "max", c => c.Double());
            AddColumn("dbo.ParameterValueTypes", "min", c => c.Double());
            AddColumn("dbo.ParameterValueTypes", "measurement", c => c.String());
            AddColumn("dbo.ParameterValueTypes", "parameterTypeType_Id", c => c.String());
            AddColumn("dbo.ParameterValueTypes", "parameterTypeID", c => c.Int());
            AddColumn("dbo.ParameterValueTypes", "parameterSelectionTypeValueID", c => c.Int());
            AddColumn("dbo.ParameterValueTypes", "isPlannedValue", c => c.Boolean());
            AddColumn("dbo.ParameterValueTypes", "values", c => c.String());
            AddColumn("dbo.ParameterValueTypes", "codes", c => c.String());
            AddColumn("dbo.ParameterValueTypes", "parameterTypeType_Id1", c => c.String());
            AddColumn("dbo.ParameterValueTypes", "parameterTypeID1", c => c.Int());
            AddColumn("dbo.ParameterValueTypes", "parameterTextTypeValueID", c => c.Int());
            AddColumn("dbo.ParameterValueTypes", "parameterTypeType_Id2", c => c.String());
            AddColumn("dbo.ParameterValueTypes", "parameterTypeID2", c => c.Int());
            AddColumn("dbo.ParameterValueTypes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddForeignKey("dbo.ParameterBaseTypes", "ParameterType_parameterTypeID", "dbo.ParameterTypes", "parameterTypeID");
            CreateIndex("dbo.ParameterBaseTypes", "ParameterType_parameterTypeID");
            DropTable("dbo.ParameterRangeTypeValues");
            DropTable("dbo.ParameterSelectionTypeValues");
            DropTable("dbo.ParameterTextTypeValues");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ParameterTextTypeValues",
                c => new
                    {
                        parameterTextTypeValueID = c.Int(nullable: false, identity: true),
                        parameterTypeType_Id = c.String(),
                        parameterTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.parameterTextTypeValueID);
            
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
                .PrimaryKey(t => t.parameterSelectionTypeValueID);
            
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
                .PrimaryKey(t => t.parameterRangeTypeValueID);
            
            DropIndex("dbo.ParameterBaseTypes", new[] { "ParameterType_parameterTypeID" });
            DropForeignKey("dbo.ParameterBaseTypes", "ParameterType_parameterTypeID", "dbo.ParameterTypes");
            DropColumn("dbo.ParameterValueTypes", "Discriminator");
            DropColumn("dbo.ParameterValueTypes", "parameterTypeID2");
            DropColumn("dbo.ParameterValueTypes", "parameterTypeType_Id2");
            DropColumn("dbo.ParameterValueTypes", "parameterTextTypeValueID");
            DropColumn("dbo.ParameterValueTypes", "parameterTypeID1");
            DropColumn("dbo.ParameterValueTypes", "parameterTypeType_Id1");
            DropColumn("dbo.ParameterValueTypes", "codes");
            DropColumn("dbo.ParameterValueTypes", "values");
            DropColumn("dbo.ParameterValueTypes", "isPlannedValue");
            DropColumn("dbo.ParameterValueTypes", "parameterSelectionTypeValueID");
            DropColumn("dbo.ParameterValueTypes", "parameterTypeID");
            DropColumn("dbo.ParameterValueTypes", "parameterTypeType_Id");
            DropColumn("dbo.ParameterValueTypes", "measurement");
            DropColumn("dbo.ParameterValueTypes", "min");
            DropColumn("dbo.ParameterValueTypes", "max");
            DropColumn("dbo.ParameterValueTypes", "isDouble");
            DropColumn("dbo.ParameterValueTypes", "extraMin");
            DropColumn("dbo.ParameterValueTypes", "extraMax");
            DropColumn("dbo.ParameterValueTypes", "defaultValue");
            DropColumn("dbo.ParameterValueTypes", "parameterRangeTypeValueID");
            DropColumn("dbo.ParameterBaseTypes", "ParameterType_parameterTypeID");
            CreateIndex("dbo.ParameterTextTypeValues", "parameterTypeID");
            CreateIndex("dbo.ParameterSelectionTypeValues", "parameterTypeID");
            CreateIndex("dbo.ParameterRangeTypeValues", "parameterTypeID");
            AddForeignKey("dbo.ParameterTextTypeValues", "parameterTypeID", "dbo.ParameterTypes", "parameterTypeID", cascadeDelete: true);
            AddForeignKey("dbo.ParameterSelectionTypeValues", "parameterTypeID", "dbo.ParameterTypes", "parameterTypeID", cascadeDelete: true);
            AddForeignKey("dbo.ParameterRangeTypeValues", "parameterTypeID", "dbo.ParameterTypes", "parameterTypeID", cascadeDelete: true);
        }
    }
}
