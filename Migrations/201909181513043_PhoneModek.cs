namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneModek : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phones", "Callee_CalleeId", "dbo.Callees");
            DropIndex("dbo.Phones", new[] { "Callee_CalleeId" });
            RenameColumn(table: "dbo.Phones", name: "Callee_CalleeId", newName: "CalleeId");
            AlterColumn("dbo.Phones", "CalleeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Phones", "CalleeId");
            AddForeignKey("dbo.Phones", "CalleeId", "dbo.Callees", "CalleeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "CalleeId", "dbo.Callees");
            DropIndex("dbo.Phones", new[] { "CalleeId" });
            AlterColumn("dbo.Phones", "CalleeId", c => c.Int());
            RenameColumn(table: "dbo.Phones", name: "CalleeId", newName: "Callee_CalleeId");
            CreateIndex("dbo.Phones", "Callee_CalleeId");
            AddForeignKey("dbo.Phones", "Callee_CalleeId", "dbo.Callees", "CalleeId");
        }
    }
}
