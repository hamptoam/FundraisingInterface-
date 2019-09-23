namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeededData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Funds", "DailyFunds", c => c.Double(nullable: false));
            AlterColumn("dbo.Funds", "WeeklyFunds", c => c.Double(nullable: false));
            AlterColumn("dbo.Funds", "MonthlyFunds", c => c.Double(nullable: false));
            AlterColumn("dbo.Funds", "QuarterlyFunds", c => c.Double(nullable: false));
            AlterColumn("dbo.Funds", "YearlyFunds", c => c.Double(nullable: false));
            AlterColumn("dbo.CampaignFunds", "FundAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CampaignFunds", "FundAmount", c => c.Int(nullable: false));
            AlterColumn("dbo.Funds", "YearlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Funds", "QuarterlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Funds", "MonthlyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Funds", "WeeklyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Funds", "DailyFunds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
