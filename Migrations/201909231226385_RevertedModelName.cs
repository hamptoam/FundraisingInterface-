namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertedModelName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EmployeeDatas", newName: "DataViewModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DataViewModels", newName: "EmployeeDatas");
        }
    }
}
