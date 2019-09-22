namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoubleCheck : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeCampaigns", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeCampaigns", "Campaign_CampaignId", "dbo.Campaigns");
            DropIndex("dbo.EmployeeCampaigns", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.EmployeeCampaigns", new[] { "Campaign_CampaignId" });
            AddColumn("dbo.Campaigns", "Employee_EmployeeId", c => c.Int());
            AddColumn("dbo.Employees", "QuantityGifts", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "WeeklyQuantityGifts", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Campaign_CampaignId", c => c.Int());
            AddColumn("dbo.Employees", "Campaign_CampaignId1", c => c.Int());
            CreateIndex("dbo.Campaigns", "Employee_EmployeeId");
            CreateIndex("dbo.Employees", "Campaign_CampaignId");
            CreateIndex("dbo.Employees", "Campaign_CampaignId1");
            AddForeignKey("dbo.Employees", "Campaign_CampaignId", "dbo.Campaigns", "CampaignId");
            AddForeignKey("dbo.Campaigns", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Employees", "Campaign_CampaignId1", "dbo.Campaigns", "CampaignId");
            DropTable("dbo.EmployeeCampaigns");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeCampaigns",
                c => new
                    {
                        Employee_EmployeeId = c.Int(nullable: false),
                        Campaign_CampaignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeId, t.Campaign_CampaignId });
            
            DropForeignKey("dbo.Employees", "Campaign_CampaignId1", "dbo.Campaigns");
            DropForeignKey("dbo.Campaigns", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Campaign_CampaignId", "dbo.Campaigns");
            DropIndex("dbo.Employees", new[] { "Campaign_CampaignId1" });
            DropIndex("dbo.Employees", new[] { "Campaign_CampaignId" });
            DropIndex("dbo.Campaigns", new[] { "Employee_EmployeeId" });
            DropColumn("dbo.Employees", "Campaign_CampaignId1");
            DropColumn("dbo.Employees", "Campaign_CampaignId");
            DropColumn("dbo.Employees", "WeeklyQuantityGifts");
            DropColumn("dbo.Employees", "QuantityGifts");
            DropColumn("dbo.Campaigns", "Employee_EmployeeId");
            CreateIndex("dbo.EmployeeCampaigns", "Campaign_CampaignId");
            CreateIndex("dbo.EmployeeCampaigns", "Employee_EmployeeId");
            AddForeignKey("dbo.EmployeeCampaigns", "Campaign_CampaignId", "dbo.Campaigns", "CampaignId", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeCampaigns", "Employee_EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
    }
}
