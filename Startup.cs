using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fundraising_Capstone.Startup))]
namespace Fundraising_Capstone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
