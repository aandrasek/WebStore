using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebStore.MVC.Startup))]
namespace WebStore.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
