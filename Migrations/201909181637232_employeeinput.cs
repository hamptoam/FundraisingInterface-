namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeinput : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "input", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "input");
        }
    }
}
