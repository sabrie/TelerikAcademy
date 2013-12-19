using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmeraldForum.Startup))]
namespace EmeraldForum
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
