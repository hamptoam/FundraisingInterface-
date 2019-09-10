namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JunctionTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Callees",
                c => new
                    {
                        CalleeId = c.Int(nullable: false, identity: true),
                        phoneNumber = c.Int(nullable: false),
                        firstName = c.String(),
                        lastName = c.String(),
                        Address = c.String(),
                        callCount = c.Int(nullable: false),
                        answerCount = c.Int(nullable: false),
                        lastCallDate = c.DateTime(nullable: false),
                        lastCallTime = c.DateTime(nullable: false),
                        nextCallDate = c.DateTime(nullable: false),
                        nextCallTime = c.DateTime(nullable: false),
                        calleeDemeanor = c.String(),
                        isInterested = c.Boolean(nullable: false),
                        CampaignId = c.Int(nullable: false),
                        Callee_CalleeId = c.Int(),
                        Campaign_CampaignId = c.Int(),
                        Employee_EmployeeId = c.Int(),
                        Manager_ManagerId = c.Int(),
                        Campaign_CampaignId1 = c.Int(),
                    })
                .PrimaryKey(t => t.CalleeId)
                .ForeignKey("dbo.Callees", t => t.Callee_CalleeId)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_CampaignId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.Managers", t => t.Manager_ManagerId)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_CampaignId1)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId, cascadeDelete: true)
                .Index(t => t.CampaignId)
                .Index(t => t.Callee_CalleeId)
                .Index(t => t.Campaign_CampaignId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Manager_ManagerId)
                .Index(t => t.Campaign_CampaignId1);
            
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        CampaignId = c.Int(nullable: false, identity: true),
                        dailyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        weeklyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        monthlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        yearlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        campaignManager_ManagerId = c.Int(),
                    })
                .PrimaryKey(t => t.CampaignId)
                .ForeignKey("dbo.Managers", t => t.campaignManager_ManagerId)
                .Index(t => t.campaignManager_ManagerId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.ManagerId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        userName = c.String(),
                        passWord = c.String(),
                        dailyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        weeklyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        monthlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quarterlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        yearlyFunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        callee_CalleeId = c.Int(),
                        Manager_ManagerId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Callees", t => t.callee_CalleeId)
                .ForeignKey("dbo.Managers", t => t.Manager_ManagerId)
                .Index(t => t.callee_CalleeId)
                .Index(t => t.Manager_ManagerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EmployeeCampaigns",
                c => new
                    {
                        Employee_EmployeeId = c.Int(nullable: false),
                        Campaign_CampaignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeId, t.Campaign_CampaignId })
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_CampaignId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Campaign_CampaignId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Callees", "CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.Callees", "Campaign_CampaignId1", "dbo.Campaigns");
            DropForeignKey("dbo.Callees", "Manager_ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Employees", "Manager_ManagerId", "dbo.Managers");
            DropForeignKey("dbo.EmployeeCampaigns", "Campaign_CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.EmployeeCampaigns", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Callees", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "callee_CalleeId", "dbo.Callees");
            DropForeignKey("dbo.Campaigns", "campaignManager_ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Callees", "Campaign_CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.Callees", "Callee_CalleeId", "dbo.Callees");
            DropIndex("dbo.EmployeeCampaigns", new[] { "Campaign_CampaignId" });
            DropIndex("dbo.EmployeeCampaigns", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Employees", new[] { "Manager_ManagerId" });
            DropIndex("dbo.Employees", new[] { "callee_CalleeId" });
            DropIndex("dbo.Campaigns", new[] { "campaignManager_ManagerId" });
            DropIndex("dbo.Callees", new[] { "Campaign_CampaignId1" });
            DropIndex("dbo.Callees", new[] { "Manager_ManagerId" });
            DropIndex("dbo.Callees", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Callees", new[] { "Campaign_CampaignId" });
            DropIndex("dbo.Callees", new[] { "Callee_CalleeId" });
            DropIndex("dbo.Callees", new[] { "CampaignId" });
            DropTable("dbo.EmployeeCampaigns");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Employees");
            DropTable("dbo.Managers");
            DropTable("dbo.Campaigns");
            DropTable("dbo.Callees");
        }
    }
}
