namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneModelOops : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phones", "Callee_CalleeId", "dbo.Callees");
            DropIndex("dbo.Phones", new[] { "Callee_CalleeId" });
            AddColumn("dbo.Phones", "CalleeId", c => c.Int(nullable: false));
            DropColumn("dbo.Phones", "Callee_CalleeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phones", "Callee_CalleeId", c => c.Int());
            DropColumn("dbo.Phones", "CalleeId");
            CreateIndex("dbo.Phones", "Callee_CalleeId");
            AddForeignKey("dbo.Phones", "Callee_CalleeId", "dbo.Callees", "CalleeId");
        }
    }
}
