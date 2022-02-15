using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetKorea.Startup))]
namespace DotNetKorea
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
