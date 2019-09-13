namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Callees", "lastCallDate", c => c.DateTime());
            AlterColumn("dbo.Callees", "lastCallTime", c => c.DateTime());
            AlterColumn("dbo.Callees", "nextCallDate", c => c.DateTime());
            AlterColumn("dbo.Callees", "nextCallTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Callees", "nextCallTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Callees", "nextCallDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Callees", "lastCallTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Callees", "lastCallDate", c => c.DateTime(nullable: false));
        }
    }
}
