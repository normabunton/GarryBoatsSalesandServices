using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GarryBoats.Startup))]
namespace GarryBoats
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
