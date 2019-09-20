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
            new Callee() { CalleeId = 1, phoneNumber = "+12622475847", firstName = "Amelia", lastName = "Hampton", Address = "1928 E Trowbridge St", City = "Milwaukee", State = "Wisconsin", zipCode = 53207, callCount = 0, answerCount = 0 });
            new Callee() { CalleeId = 2, phoneNumber = "+12175497249", firstName = "Everett", lastName = "Hampton", Address = "3029 W Marshall Ave", City = "Mattoon", State = "Illinois", zipCode = 61938, callCount = 0, answerCount = 0 };
            new Callee() { CalleeId = 3, phoneNumber = "+14145265321", firstName = "Daniel", lastName = "Dickover", Address = "3716 S Herman St", City = "Milwuakee", State = "Wisconsin", zipCode = 53207, callCount = 0, answerCount = 0 };
        }
    }
}
