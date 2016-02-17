using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleApp.Startup))]
namespace SimpleApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
