using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventApp.Startup))]
namespace EventApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
