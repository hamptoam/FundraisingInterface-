namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCalleeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Callees", "City", c => c.String());
            AddColumn("dbo.Callees", "State", c => c.String());
            AddColumn("dbo.Callees", "zipCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Callees", "phoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Callees", "phoneNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Callees", "zipCode");
            DropColumn("dbo.Callees", "State");
            DropColumn("dbo.Callees", "City");
        }
    }
}
