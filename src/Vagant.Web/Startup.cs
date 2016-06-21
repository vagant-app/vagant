using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vagant.Web.Startup))]
namespace Vagant.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
