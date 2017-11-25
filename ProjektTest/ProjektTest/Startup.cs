using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektTest.Startup))]
namespace ProjektTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
