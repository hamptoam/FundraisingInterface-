namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDbContext : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId1", newName: "Campaign_CampaignId");
            RenameColumn(table: "dbo.Employees", name: "__mig_tmp__0", newName: "Campaign_CampaignId1");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId1", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId", newName: "IX_Campaign_CampaignId1");
            RenameIndex(table: "dbo.Employees", name: "__mig_tmp__0", newName: "IX_Campaign_CampaignId");
            CreateTable(
                "dbo.CalleeFunds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CalleeId = c.Int(nullable: false),
                        FundId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Callees", t => t.CalleeId, cascadeDelete: true)
                .ForeignKey("dbo.Funds", t => t.FundId, cascadeDelete: true)
                .Index(t => t.CalleeId)
                .Index(t => t.FundId);
            
            CreateTable(
                "dbo.Funds",
                c => new
                    {
                        FundId = c.Int(nullable: false, identity: true),
                        DailyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WeeklyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonthlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuarterlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        YearlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FundId);
            
            CreateTable(
                "dbo.CampaignFunds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CampaignId = c.Int(nullable: false),
                        FundId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId, cascadeDelete: true)
                .ForeignKey("dbo.Funds", t => t.FundId, cascadeDelete: true)
                .Index(t => t.CampaignId)
                .Index(t => t.FundId);
            
            CreateTable(
                "dbo.EmployeeFunds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        FundId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Funds", t => t.FundId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.FundId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeFunds", "FundId", "dbo.Funds");
            DropForeignKey("dbo.EmployeeFunds", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CampaignFunds", "FundId", "dbo.Funds");
            DropForeignKey("dbo.CampaignFunds", "CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.CalleeFunds", "FundId", "dbo.Funds");
            DropForeignKey("dbo.CalleeFunds", "CalleeId", "dbo.Callees");
            DropIndex("dbo.EmployeeFunds", new[] { "FundId" });
            DropIndex("dbo.EmployeeFunds", new[] { "EmployeeId" });
            DropIndex("dbo.CampaignFunds", new[] { "FundId" });
            DropIndex("dbo.CampaignFunds", new[] { "CampaignId" });
            DropIndex("dbo.CalleeFunds", new[] { "FundId" });
            DropIndex("dbo.CalleeFunds", new[] { "CalleeId" });
            DropTable("dbo.EmployeeFunds");
            DropTable("dbo.CampaignFunds");
            DropTable("dbo.Funds");
            DropTable("dbo.CalleeFunds");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId1", newName: "IX_Campaign_CampaignId");
            RenameIndex(table: "dbo.Employees", name: "__mig_tmp__0", newName: "IX_Campaign_CampaignId1");
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId1", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId", newName: "Campaign_CampaignId1");
            RenameColumn(table: "dbo.Employees", name: "__mig_tmp__0", newName: "Campaign_CampaignId");
        }
    }
}
