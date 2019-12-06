namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phoneCallee : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId1", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId", newName: "Campaign_CampaignId1");
            RenameColumn(table: "dbo.Employees", name: "__mig_tmp__0", newName: "Campaign_CampaignId");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId1", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId", newName: "IX_Campaign_CampaignId1");
            RenameIndex(table: "dbo.Employees", name: "__mig_tmp__0", newName: "IX_Campaign_CampaignId");
            AddColumn("dbo.Callees", "Phone_Id", c => c.Int());
            CreateIndex("dbo.Callees", "Phone_Id");
            AddForeignKey("dbo.Callees", "Phone_Id", "dbo.Phones", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Callees", "Phone_Id", "dbo.Phones");
            DropIndex("dbo.Callees", new[] { "Phone_Id" });
            DropColumn("dbo.Callees", "Phone_Id");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Employees", name: "IX_Campaign_CampaignId1", newName: "IX_Campaign_CampaignId");
            RenameIndex(table: "dbo.Employees", name: "__mig_tmp__0", newName: "IX_Campaign_CampaignId1");
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Employees", name: "Campaign_CampaignId1", newName: "Campaign_CampaignId");
            RenameColumn(table: "dbo.Employees", name: "__mig_tmp__0", newName: "Campaign_CampaignId1");
        }
    }
}
