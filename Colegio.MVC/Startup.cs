using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Colegio.MVC.Startup))]
namespace Colegio.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
