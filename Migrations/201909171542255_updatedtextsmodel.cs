namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedtextsmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "outgoingText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phones", "outgoingText");
        }
    }
}
