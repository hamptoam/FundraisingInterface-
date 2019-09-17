namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId1", newName: "Campaign_CampaignId");
            RenameColumn(table: "dbo.Employees", name: "__mig_tmp__0", newName: "Campaign_CampaignId1");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId1", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId", newName: "IX_Campaign_CampaignId1");
            RenameIndex(table: "dbo.Employees", name: "__mig_tmp__0", newName: "IX_Campaign_CampaignId");
            AddColumn("dbo.Callees", "hasResponse", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Callees", "hasResponse");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId1", newName: "IX_Campaign_CampaignId");
            RenameIndex(table: "dbo.Employees", name: "__mig_tmp__0", newName: "IX_Campaign_CampaignId1");
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId1", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId", newName: "Campaign_CampaignId1");
            RenameColumn(table: "dbo.Employees", name: "__mig_tmp__0", newName: "Campaign_CampaignId");
        }
    }
}
