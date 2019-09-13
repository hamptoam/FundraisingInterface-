namespace Fundraising_Capstone2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Fundraising_Capstone2.Models; 

    internal sealed class Configuration : DbMigrationsConfiguration<Fundraising_Capstone2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Fundraising_Capstone2.Models.ApplicationDbContext context)
        {
            context.Callees.AddOrUpdate(x => x.CalleeId,
                new Callee() { CalleeId = 1, phoneNumber = "8008675309", firstName = "Kenny", lastName = "Bloobloobloo", Address = "1928 E Trowbridge St", City = "Milwaukee", State = "Wisconsin", zipCode = 53207, callCount = 0, answerCount = 0 });
        }
    }
}
