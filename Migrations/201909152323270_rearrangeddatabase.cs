namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rearrangeddatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalleeCampaigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CalleeId = c.Int(nullable: false),
                        CampaignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Callees", t => t.CalleeId, cascadeDelete: true)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId, cascadeDelete: true)
                .Index(t => t.CalleeId)
                .Index(t => t.CampaignId);
            
            CreateTable(
                "dbo.Callees",
                c => new
                    {
                        CalleeId = c.Int(nullable: false, identity: true),
                        phoneNumber = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        zipCode = c.Int(nullable: false),
                        callCount = c.Int(nullable: false),
                        answerCount = c.Int(nullable: false),
                        giftDate = c.String(),
                        lastCallDate = c.DateTime(),
                        lastCallTime = c.DateTime(),
                        nextCallDate = c.DateTime(),
                        nextCallTime = c.DateTime(),
                        calleeDemeanor = c.String(),
                        isInterested = c.Boolean(nullable: false),
                        Employee_EmployeeId = c.Int(),
                        Campaign_CampaignId = c.Int(),
                        Manager_ManagerId = c.Int(),
                    })
                .PrimaryKey(t => t.CalleeId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_CampaignId)
                .ForeignKey("dbo.Managers", t => t.Manager_ManagerId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Campaign_CampaignId)
                .Index(t => t.Manager_ManagerId);
            
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        CampaignId = c.Int(nullable: false, identity: true),
                        campaignStartDate = c.String(),
                        campaignEndDate = c.String(),
                        Employee_EmployeeId = c.Int(),
                        Manager_ManagerId = c.Int(),
                    })
                .PrimaryKey(t => t.CampaignId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.Managers", t => t.Manager_ManagerId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Manager_ManagerId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        userName = c.String(),
                        passWord = c.String(),
                        callee_CalleeId = c.Int(),
                        Campaign_CampaignId = c.Int(),
                        Campaign_CampaignId1 = c.Int(),
                        Manager_ManagerId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Callees", t => t.callee_CalleeId)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_CampaignId)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_CampaignId1)
                .ForeignKey("dbo.Managers", t => t.Manager_ManagerId)
                .Index(t => t.callee_CalleeId)
                .Index(t => t.Campaign_CampaignId)
                .Index(t => t.Campaign_CampaignId1)
                .Index(t => t.Manager_ManagerId);
            
            CreateTable(
                "dbo.CampaignEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CampaignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CampaignId);
            
            CreateTable(
                "dbo.CampaignManagers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CampaignId = c.Int(nullable: false),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId, cascadeDelete: true)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.CampaignId)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                    })
                .PrimaryKey(t => t.ManagerId);
            
            CreateTable(
                "dbo.EmployeeCallees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CalleeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Callees", t => t.CalleeId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CalleeId);
            
            CreateTable(
                "dbo.ManagerEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManagerId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ManagerId)
                .Index(t => t.EmployeeId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Phones", "Callee_CalleeId", "dbo.Callees");
            DropForeignKey("dbo.ManagerEmployees", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.ManagerEmployees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeCallees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeCallees", "CalleeId", "dbo.Callees");
            DropForeignKey("dbo.CampaignManagers", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Callees", "Manager_ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Employees", "Manager_ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Campaigns", "Manager_ManagerId", "dbo.Managers");
            DropForeignKey("dbo.CampaignManagers", "CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.CampaignEmployees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CampaignEmployees", "CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.CalleeCampaigns", "CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.Callees", "Campaign_CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.Employees", "Campaign_CampaignId1", "dbo.Campaigns");
            DropForeignKey("dbo.Employees", "Campaign_CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.Campaigns", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Callees", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "callee_CalleeId", "dbo.Callees");
            DropForeignKey("dbo.CalleeCampaigns", "CalleeId", "dbo.Callees");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Phones", new[] { "Callee_CalleeId" });
            DropIndex("dbo.ManagerEmployees", new[] { "EmployeeId" });
            DropIndex("dbo.ManagerEmployees", new[] { "ManagerId" });
            DropIndex("dbo.EmployeeCallees", new[] { "CalleeId" });
            DropIndex("dbo.EmployeeCallees", new[] { "EmployeeId" });
            DropIndex("dbo.CampaignManagers", new[] { "ManagerId" });
            DropIndex("dbo.CampaignManagers", new[] { "CampaignId" });
            DropIndex("dbo.CampaignEmployees", new[] { "CampaignId" });
            DropIndex("dbo.CampaignEmployees", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "Manager_ManagerId" });
            DropIndex("dbo.Employees", new[] { "Campaign_CampaignId1" });
            DropIndex("dbo.Employees", new[] { "Campaign_CampaignId" });
            DropIndex("dbo.Employees", new[] { "callee_CalleeId" });
            DropIndex("dbo.Campaigns", new[] { "Manager_ManagerId" });
            DropIndex("dbo.Campaigns", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Callees", new[] { "Manager_ManagerId" });
            DropIndex("dbo.Callees", new[] { "Campaign_CampaignId" });
            DropIndex("dbo.Callees", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.CalleeCampaigns", new[] { "CampaignId" });
            DropIndex("dbo.CalleeCampaigns", new[] { "CalleeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Phones");
            DropTable("dbo.ManagerEmployees");
            DropTable("dbo.EmployeeCallees");
            DropTable("dbo.Managers");
            DropTable("dbo.CampaignManagers");
            DropTable("dbo.CampaignEmployees");
            DropTable("dbo.Employees");
            DropTable("dbo.Campaigns");
            DropTable("dbo.Callees");
            DropTable("dbo.CalleeCampaigns");
        }
    }
}
