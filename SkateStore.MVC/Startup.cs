using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkateStore.MVC.Startup))]
namespace SkateStore.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
