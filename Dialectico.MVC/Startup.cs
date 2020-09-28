using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dialectico.MVC.Startup))]
namespace Dialectico.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
