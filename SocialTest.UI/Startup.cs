using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialTest.UI.Startup))]
namespace SocialTest.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
