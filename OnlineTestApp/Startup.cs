using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineTestApp.Startup))]
namespace OnlineTestApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
