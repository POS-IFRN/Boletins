using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VisaoWebForm.Startup))]
namespace VisaoWebForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
