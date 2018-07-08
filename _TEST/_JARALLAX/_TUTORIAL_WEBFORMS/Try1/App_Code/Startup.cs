using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Try1.Startup))]
namespace Try1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
