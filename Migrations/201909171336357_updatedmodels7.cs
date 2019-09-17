namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Campaigns", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Campaign_CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.Employees", "Campaign_CampaignId1", "dbo.Campaigns");
            DropForeignKey("dbo.Callees", "Campaign_CampaignId", "dbo.Campaigns");
            DropIndex("dbo.Callees", new[] { "Campaign_CampaignId" });
            DropIndex("dbo.Campaigns", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Employees", new[] { "Campaign_CampaignId" });
            DropIndex("dbo.Employees", new[] { "Campaign_CampaignId1" });
            CreateTable(
                "dbo.EmployeeCampaigns",
                c => new
                    {
                        Employee_EmployeeId = c.Int(nullable: false),
                        Campaign_CampaignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeId, t.Campaign_CampaignId })
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_CampaignId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Campaign_CampaignId);
            
            DropColumn("dbo.Callees", "Campaign_CampaignId");
            DropColumn("dbo.Campaigns", "Employee_EmployeeId");
            DropColumn("dbo.Employees", "Campaign_CampaignId");
            DropColumn("dbo.Employees", "Campaign_CampaignId1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Campaign_CampaignId1", c => c.Int());
            AddColumn("dbo.Employees", "Campaign_CampaignId", c => c.Int());
            AddColumn("dbo.Campaigns", "Employee_EmployeeId", c => c.Int());
            AddColumn("dbo.Callees", "Campaign_CampaignId", c => c.Int());
            DropForeignKey("dbo.EmployeeCampaigns", "Campaign_CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.EmployeeCampaigns", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeCampaigns", new[] { "Campaign_CampaignId" });
            DropIndex("dbo.EmployeeCampaigns", new[] { "Employee_EmployeeId" });
            DropTable("dbo.EmployeeCampaigns");
            CreateIndex("dbo.Employees", "Campaign_CampaignId1");
            CreateIndex("dbo.Employees", "Campaign_CampaignId");
            CreateIndex("dbo.Campaigns", "Employee_EmployeeId");
            CreateIndex("dbo.Callees", "Campaign_CampaignId");
            AddForeignKey("dbo.Callees", "Campaign_CampaignId", "dbo.Campaigns", "CampaignId");
            AddForeignKey("dbo.Employees", "Campaign_CampaignId1", "dbo.Campaigns", "CampaignId");
            AddForeignKey("dbo.Employees", "Campaign_CampaignId", "dbo.Campaigns", "CampaignId");
            AddForeignKey("dbo.Campaigns", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
