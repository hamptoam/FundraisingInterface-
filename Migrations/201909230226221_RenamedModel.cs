namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DataViewModels", newName: "EmployeeDatas");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.EmployeeDatas", newName: "DataViewModels");
        }
    }
}
