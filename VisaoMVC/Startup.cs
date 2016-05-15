using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VisaoMVC.Startup))]
namespace VisaoMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
