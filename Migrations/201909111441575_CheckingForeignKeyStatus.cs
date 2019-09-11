namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckingForeignKeyStatus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Callees", "CampaignId", "dbo.Campaigns");
            DropIndex("dbo.Callees", new[] { "CampaignId" });
            CreateTable(
                "dbo.CalleeCampaigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CalleeId = c.Int(nullable: false),
                        CampaignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Callees", t => t.CalleeId, cascadeDelete: true)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId, cascadeDelete: true)
                .Index(t => t.CalleeId)
                .Index(t => t.CampaignId);
            
            CreateTable(
                "dbo.CampaignEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CampaignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CampaignId);
            
            CreateTable(
                "dbo.CampaignManagers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CampaignId = c.Int(nullable: false),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId, cascadeDelete: true)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.CampaignId)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.EmployeeCallees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CalleeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Callees", t => t.CalleeId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CalleeId);
            
            CreateTable(
                "dbo.ManagerEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManagerId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ManagerId)
                .Index(t => t.EmployeeId);
            
            DropColumn("dbo.Callees", "CampaignId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Callees", "CampaignId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ManagerEmployees", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.ManagerEmployees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeCallees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeCallees", "CalleeId", "dbo.Callees");
            DropForeignKey("dbo.CampaignManagers", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.CampaignManagers", "CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.CampaignEmployees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CampaignEmployees", "CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.CalleeCampaigns", "CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.CalleeCampaigns", "CalleeId", "dbo.Callees");
            DropIndex("dbo.ManagerEmployees", new[] { "EmployeeId" });
            DropIndex("dbo.ManagerEmployees", new[] { "ManagerId" });
            DropIndex("dbo.EmployeeCallees", new[] { "CalleeId" });
            DropIndex("dbo.EmployeeCallees", new[] { "EmployeeId" });
            DropIndex("dbo.CampaignManagers", new[] { "ManagerId" });
            DropIndex("dbo.CampaignManagers", new[] { "CampaignId" });
            DropIndex("dbo.CampaignEmployees", new[] { "CampaignId" });
            DropIndex("dbo.CampaignEmployees", new[] { "EmployeeId" });
            DropIndex("dbo.CalleeCampaigns", new[] { "CampaignId" });
            DropIndex("dbo.CalleeCampaigns", new[] { "CalleeId" });
            DropTable("dbo.ManagerEmployees");
            DropTable("dbo.EmployeeCallees");
            DropTable("dbo.CampaignManagers");
            DropTable("dbo.CampaignEmployees");
            DropTable("dbo.CalleeCampaigns");
            CreateIndex("dbo.Callees", "CampaignId");
            AddForeignKey("dbo.Callees", "CampaignId", "dbo.Campaigns", "CampaignId", cascadeDelete: true);
        }
    }
}
