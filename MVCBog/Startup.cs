using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBog.Startup))]
namespace MVCBog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
