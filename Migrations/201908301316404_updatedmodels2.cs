namespace Fundraising_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Campaigns", name: "Manager_id", newName: "campaignManager_id");
            RenameIndex(table: "dbo.Campaigns", name: "IX_Manager_id", newName: "IX_campaignManager_id");
            AddColumn("dbo.Callees", "Campaign_Id", c => c.Int());
            AddColumn("dbo.Campaigns", "dailyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Campaigns", "weeklyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Campaigns", "monthlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Campaigns", "yearlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Employees", "Campaign_Id", c => c.Int());
            CreateIndex("dbo.Callees", "Campaign_Id");
            CreateIndex("dbo.Employees", "Campaign_Id");
            AddForeignKey("dbo.Employees", "Campaign_Id", "dbo.Campaigns", "Id");
            AddForeignKey("dbo.Callees", "Campaign_Id", "dbo.Campaigns", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Callees", "Campaign_Id", "dbo.Campaigns");
            DropForeignKey("dbo.Employees", "Campaign_Id", "dbo.Campaigns");
            DropIndex("dbo.Employees", new[] { "Campaign_Id" });
            DropIndex("dbo.Callees", new[] { "Campaign_Id" });
            DropColumn("dbo.Employees", "Campaign_Id");
            DropColumn("dbo.Campaigns", "yearlyFunds");
            DropColumn("dbo.Campaigns", "monthlyFunds");
            DropColumn("dbo.Campaigns", "weeklyFunds");
            DropColumn("dbo.Campaigns", "dailyFunds");
            DropColumn("dbo.Callees", "Campaign_Id");
            RenameIndex(table: "dbo.Campaigns", name: "IX_campaignManager_id", newName: "IX_Manager_id");
            RenameColumn(table: "dbo.Campaigns", name: "campaignManager_id", newName: "Manager_id");
        }
    }
}
