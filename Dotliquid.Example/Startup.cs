using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dotliquid.Example.Startup))]
namespace Dotliquid.Example
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
