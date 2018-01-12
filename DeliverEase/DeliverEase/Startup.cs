using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeliverEase.Startup))]
namespace DeliverEase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
