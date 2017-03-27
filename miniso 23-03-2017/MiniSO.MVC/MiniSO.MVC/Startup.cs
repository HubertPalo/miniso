using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniSO.MVC.Startup))]
namespace MiniSO.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
