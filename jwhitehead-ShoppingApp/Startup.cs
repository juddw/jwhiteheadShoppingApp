using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jwhiteheadShoppingApp.Startup))]
namespace jwhiteheadShoppingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
