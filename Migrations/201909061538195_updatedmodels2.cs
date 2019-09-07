namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Callees", "Campaign_Id", "dbo.Campaigns");
            AddColumn("dbo.Callees", "Callee_phoneNumber", c => c.Int());
            AddColumn("dbo.Callees", "Campaign_Id1", c => c.Int());
            CreateIndex("dbo.Callees", "Callee_phoneNumber");
            CreateIndex("dbo.Callees", "Campaign_Id1");
            AddForeignKey("dbo.Callees", "Callee_phoneNumber", "dbo.Callees", "phoneNumber");
            AddForeignKey("dbo.Callees", "Campaign_Id", "dbo.Campaigns", "Id");
            AddForeignKey("dbo.Callees", "Campaign_Id1", "dbo.Campaigns", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Callees", "Campaign_Id1", "dbo.Campaigns");
            DropForeignKey("dbo.Callees", "Campaign_Id", "dbo.Campaigns");
            DropForeignKey("dbo.Callees", "Callee_phoneNumber", "dbo.Callees");
            DropIndex("dbo.Callees", new[] { "Campaign_Id1" });
            DropIndex("dbo.Callees", new[] { "Callee_phoneNumber" });
            DropColumn("dbo.Callees", "Campaign_Id1");
            DropColumn("dbo.Callees", "Callee_phoneNumber");
            AddForeignKey("dbo.Callees", "Campaign_Id", "dbo.Campaigns", "Id");
        }
    }
}
