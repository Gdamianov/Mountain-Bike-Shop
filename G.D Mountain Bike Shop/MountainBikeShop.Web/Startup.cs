using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MountainBikeShop.Web.Startup))]
namespace MountainBikeShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
