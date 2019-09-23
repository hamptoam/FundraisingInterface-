namespace Fundraising_Capstone2.Migrations
{
    using Fundraising_Capstone2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Fundraising_Capstone2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Fundraising_Capstone2.Models.ApplicationDbContext context)
        {
            context.Callees.AddOrUpdate(x => x.CalleeId,
            new Callee() { CalleeId = 1, phoneNumber = "+12629332309", firstName = "Amelia", lastName = "Hampton", Address = "1928 E Trowbridge St", City = "Milwaukee", State = "Wisconsin", zipCode = 53207, callCount = 0, answerCount = 0 });
            new Callee() { CalleeId = 2, phoneNumber = "+12175497249", firstName = "Everett", lastName = "Hampton", Address = "3029 W Marshall Ave", City = "Mattoon", State = "Illinois", zipCode = 61938, callCount = 0, answerCount = 0 };
            new Callee() { CalleeId = 3, phoneNumber = "+14145265321", firstName = "Daniel", lastName = "Dickover", Address = "3716 S Herman St", City = "Milwuakee", State = "Wisconsin", zipCode = 53207, callCount = 0, answerCount = 0 };


            context.Employees.AddOrUpdate(x => x.EmployeeId,
                new Employee() { EmployeeId = 1, FirstName = "Bo", LastName = "Jackson", UserName = "BoJack", DailyCalls = 200, QuantityGifts = 4, WeeklyCalls = 1246, WeeklyQuantityGifts = 23 },
                new Employee() { EmployeeId = 2, FirstName = "Isaac", LastName = "Brock", UserName = "IsBrock", DailyCalls = 282, QuantityGifts = 6, WeeklyCalls = 1484, WeeklyQuantityGifts = 20 }
                );


            context.Campaigns.AddOrUpdate(x => x.CampaignId,
                new Campaign() { CampaignId = 1, CampaignName = "UPAF", campaignStartDate = "2019/08/01", campaignEndDate = "2020/01/01" },
                new Campaign() { CampaignId = 2, CampaignName = "HRC", campaignStartDate = "2019/01/01", campaignEndDate = "2019/12/31" }
                );
            context.CampaignFunds.AddOrUpdate(x => x.Id,
                new CampaignFunds() { Id = 1, CampaignId = 1, FundId = 1, FundAmount = 126567.00 },
                new CampaignFunds() { Id = 2, CampaignId = 2, FundId = 2, FundAmount = 247324.00 }
                );
            context.Funds.AddOrUpdate(x => x.FundId,
                new Funds() { FundId = 1, DailyFunds = 537.00, WeeklyFunds = 2789.50, MonthlyFunds = 10032.75, QuarterlyFunds = 25422.00, YearlyFunds = 25422.00 },
                new Funds() { FundId = 2, DailyFunds = 432.50, WeeklyFunds = 1892.00, MonthlyFunds = 11427.00, QuarterlyFunds = 11427.00, YearlyFunds = 68982.00 }
                );

            context.CampaignEmployees.AddOrUpdate(x => x.Id,
                new CampaignEmployee() { Id = 1, EmployeeId = 1, CampaignId = 1 },
                new CampaignEmployee() { Id = 2, EmployeeId = 2, CampaignId = 2 }
                );

            context.EmployeeFunds.AddOrUpdate(x => x.Id,
                new EmployeeFunds() { Id = 1, EmployeeId = 1, FundId = 1 },
                new EmployeeFunds() { Id = 2, EmployeeId = 2, FundId = 2 }
                );
        }
    }
}
