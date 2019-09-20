namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "Callee_CalleeId", c => c.Int());
            CreateIndex("dbo.Phones", "Callee_CalleeId");
            AddForeignKey("dbo.Phones", "Callee_CalleeId", "dbo.Callees", "CalleeId");
            DropColumn("dbo.Employees", "input");
            DropColumn("dbo.Managers", "userName");
            DropColumn("dbo.Phones", "CalleeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phones", "CalleeId", c => c.Int(nullable: false));
            AddColumn("dbo.Managers", "userName", c => c.String());
            AddColumn("dbo.Employees", "input", c => c.String());
            DropForeignKey("dbo.Phones", "Callee_CalleeId", "dbo.Callees");
            DropIndex("dbo.Phones", new[] { "Callee_CalleeId" });
            DropColumn("dbo.Phones", "Callee_CalleeId");
        }
    }
}
