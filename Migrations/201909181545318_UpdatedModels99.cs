namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels99 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phones", "CalleeId", "dbo.Callees");
            DropIndex("dbo.Phones", new[] { "CalleeId" });
            RenameColumn(table: "dbo.Phones", name: "CalleeId", newName: "Callee_CalleeId");
            AlterColumn("dbo.Phones", "Callee_CalleeId", c => c.Int());
            CreateIndex("dbo.Phones", "Callee_CalleeId");
            AddForeignKey("dbo.Phones", "Callee_CalleeId", "dbo.Callees", "CalleeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "Callee_CalleeId", "dbo.Callees");
            DropIndex("dbo.Phones", new[] { "Callee_CalleeId" });
            AlterColumn("dbo.Phones", "Callee_CalleeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Phones", name: "Callee_CalleeId", newName: "CalleeId");
            CreateIndex("dbo.Phones", "CalleeId");
            AddForeignKey("dbo.Phones", "CalleeId", "dbo.Callees", "CalleeId", cascadeDelete: true);
        }
    }
}
