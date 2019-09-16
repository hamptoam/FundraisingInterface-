using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fundraising_Capstone2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Callee> Callees { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<Funds> Funds { get; set; }

        public DbSet<CalleeCampaign> CalleeCampaigns { get; set; }

        public DbSet<CampaignEmployee> CampaignEmployees { get; set; }

        public DbSet<CampaignManager> CampaignManagers { get; set; }

        public DbSet<EmployeeCallee> EmployeeCallees { get; set; }

        public DbSet<ManagerEmployee> ManagerEmployees { get; set; }

        public DbSet<CalleeFunds> CalleeFunds { get; set; }

        public DbSet<CampaignFunds> CampaignFunds { get; set; }

        public DbSet<EmployeeFunds> EmployeeFunds { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Fundraising_Capstone2.Models.Phone> Phones { get; set; }
    }
}