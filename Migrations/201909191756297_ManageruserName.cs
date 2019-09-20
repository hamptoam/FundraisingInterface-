namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManageruserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Managers", "userName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Managers", "userName");
        }
    }
}
