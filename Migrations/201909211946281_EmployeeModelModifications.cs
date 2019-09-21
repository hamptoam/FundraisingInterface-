namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeModelModifications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "dailyCalls", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "weeklyCalls", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "weeklyCalls");
            DropColumn("dbo.Employees", "dailyCalls");
            DropTable("dbo.DataViewModels");
        }
    }
}
