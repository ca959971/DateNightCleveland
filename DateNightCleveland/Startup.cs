using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DateNightCleveland.Startup))]
namespace DateNightCleveland
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
