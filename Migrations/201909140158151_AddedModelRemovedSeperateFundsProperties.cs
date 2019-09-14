namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModelRemovedSeperateFundsProperties : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Campaigns", name: "campaignManager_ManagerId", newName: "Manager_ManagerId");
            RenameIndex(table: "dbo.Campaigns", name: "IX_campaignManager_ManagerId", newName: "IX_Manager_ManagerId");
            DropColumn("dbo.Campaigns", "dailyFunds");
            DropColumn("dbo.Campaigns", "weeklyFunds");
            DropColumn("dbo.Campaigns", "monthlyFunds");
            DropColumn("dbo.Campaigns", "yearlyFunds");
            DropColumn("dbo.Managers", "totalWeeklyFunds");
            DropColumn("dbo.Managers", "totalMonthlyFunds");
            DropColumn("dbo.Managers", "totalQuarterlyFunds");
            DropColumn("dbo.Managers", "totalYearlyFunds");
            DropColumn("dbo.Managers", "weeklyCampaignFunds");
            DropColumn("dbo.Managers", "totalDailyFunds");
            DropColumn("dbo.Managers", "dailyCampaignFunds");
            DropColumn("dbo.Managers", "dailyEmployeeFunds");
            DropColumn("dbo.Managers", "weeklyEmployeeFunds");
            DropColumn("dbo.Managers", "weeklyFunds");
            DropColumn("dbo.Managers", "monthlyFunds");
            DropColumn("dbo.Managers", "quarterlyFunds");
            DropColumn("dbo.Managers", "yearlyFunds");
            DropColumn("dbo.Employees", "dailyFunds");
            DropColumn("dbo.Employees", "weeklyFunds");
            DropColumn("dbo.Employees", "monthlyFunds");
            DropColumn("dbo.Employees", "quarterlyFunds");
            DropColumn("dbo.Employees", "yearlyFunds");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "yearlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Employees", "quarterlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Employees", "monthlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Employees", "weeklyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Employees", "dailyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Managers", "yearlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Managers", "quarterlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Managers", "monthlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Managers", "weeklyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Managers", "weeklyEmployeeFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Managers", "dailyEmployeeFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Managers", "dailyCampaignFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Managers", "totalDailyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Managers", "weeklyCampaignFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Managers", "totalYearlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Managers", "totalQuarterlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Managers", "totalMonthlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Managers", "totalWeeklyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Campaigns", "yearlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Campaigns", "monthlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Campaigns", "weeklyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Campaigns", "dailyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            RenameIndex(table: "dbo.Campaigns", name: "IX_Manager_ManagerId", newName: "IX_campaignManager_ManagerId");
            RenameColumn(table: "dbo.Campaigns", name: "Manager_ManagerId", newName: "campaignManager_ManagerId");
        }
    }
}
