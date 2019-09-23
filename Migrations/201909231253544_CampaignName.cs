namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampaignName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaigns", "CampaignName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campaigns", "CampaignName");
        }
    }
}
