using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Shop.Api.Startup))]

namespace Shop.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
