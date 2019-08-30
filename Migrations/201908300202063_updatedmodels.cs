namespace Fundraising_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Callees",
                c => new
                    {
                        phoneNumber = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        Address = c.String(),
                        callCount = c.Int(nullable: false),
                        answerCount = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                        Manager_id = c.Int(),
                    })
                .PrimaryKey(t => t.phoneNumber)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Managers", t => t.Manager_id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Manager_id);
            
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Manager_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Managers", t => t.Manager_id)
                .Index(t => t.Manager_id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        userName = c.String(),
                        passWord = c.String(),
                        dailyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        weeklyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        monthlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quarterlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        yearlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        callee_phoneNumber = c.Int(),
                        Manager_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Callees", t => t.callee_phoneNumber)
                .ForeignKey("dbo.Managers", t => t.Manager_id)
                .Index(t => t.callee_phoneNumber)
                .Index(t => t.Manager_id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        totalWeeklyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        totalMonthlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        totalQuarterlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        totalYearlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        weeklyCampaignFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        totalDailyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dailyCampaignFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dailyEmployeeFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        weeklyEmployeeFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        weeklyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        monthlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quarterlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        yearlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Callees", "Manager_id", "dbo.Managers");
            DropForeignKey("dbo.Employees", "Manager_id", "dbo.Managers");
            DropForeignKey("dbo.Campaigns", "Manager_id", "dbo.Managers");
            DropForeignKey("dbo.Callees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "callee_phoneNumber", "dbo.Callees");
            DropIndex("dbo.Employees", new[] { "Manager_id" });
            DropIndex("dbo.Employees", new[] { "callee_phoneNumber" });
            DropIndex("dbo.Campaigns", new[] { "Manager_id" });
            DropIndex("dbo.Callees", new[] { "Manager_id" });
            DropIndex("dbo.Callees", new[] { "Employee_Id" });
            DropTable("dbo.Managers");
            DropTable("dbo.Employees");
            DropTable("dbo.Campaigns");
            DropTable("dbo.Callees");
        }
    }
}
