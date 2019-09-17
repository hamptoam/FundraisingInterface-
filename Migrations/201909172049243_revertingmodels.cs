namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revertingmodels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Phones", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phones", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
