namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Callee_CalleeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Callees", t => t.Callee_CalleeId)
                .Index(t => t.Callee_CalleeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "Callee_CalleeId", "dbo.Callees");
            DropIndex("dbo.Phones", new[] { "Callee_CalleeId" });
            DropTable("dbo.Phones");
        }
    }
}
