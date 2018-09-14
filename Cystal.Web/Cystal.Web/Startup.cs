using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cystal.Web.Startup))]
namespace Cystal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
