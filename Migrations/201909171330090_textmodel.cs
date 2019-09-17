namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class textmodel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId1", newName: "Campaign_CampaignId");
            RenameColumn(table: "dbo.Employees", name: "__mig_tmp__0", newName: "Campaign_CampaignId1");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId1", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId", newName: "IX_Campaign_CampaignId1");
            RenameIndex(table: "dbo.Employees", name: "__mig_tmp__0", newName: "IX_Campaign_CampaignId");
            AddColumn("dbo.Phones", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Phones", "Employee_EmployeeId", c => c.Int());
            CreateIndex("dbo.Phones", "Employee_EmployeeId");
            AddForeignKey("dbo.Phones", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Phones", new[] { "Employee_EmployeeId" });
            DropColumn("dbo.Phones", "Employee_EmployeeId");
            DropColumn("dbo.Phones", "Discriminator");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId1", newName: "IX_Campaign_CampaignId");
            RenameIndex(table: "dbo.Employees", name: "__mig_tmp__0", newName: "IX_Campaign_CampaignId1");
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId1", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId", newName: "Campaign_CampaignId1");
            RenameColumn(table: "dbo.Employees", name: "__mig_tmp__0", newName: "Campaign_CampaignId");
        }
    }
}
