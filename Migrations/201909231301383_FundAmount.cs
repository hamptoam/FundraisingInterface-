namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FundAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CampaignFunds", "FundAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CampaignFunds", "FundAmount");
        }
    }
}
