namespace BookKeeping.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonthlyData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Income = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MonthlyReconciliation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonthlyDataId = c.Int(nullable: false),
                        ReconciliationId = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MonthlyData", t => t.MonthlyDataId, cascadeDelete: true)
                .ForeignKey("dbo.Reconciliation", t => t.ReconciliationId, cascadeDelete: true)
                .Index(t => t.MonthlyDataId)
                .Index(t => t.ReconciliationId);
            
            CreateTable(
                "dbo.Reconciliation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonthlyReconciliation", "ReconciliationId", "dbo.Reconciliation");
            DropForeignKey("dbo.MonthlyReconciliation", "MonthlyDataId", "dbo.MonthlyData");
            DropIndex("dbo.MonthlyReconciliation", new[] { "ReconciliationId" });
            DropIndex("dbo.MonthlyReconciliation", new[] { "MonthlyDataId" });
            DropTable("dbo.Reconciliation");
            DropTable("dbo.MonthlyReconciliation");
            DropTable("dbo.MonthlyData");
        }
    }
}
