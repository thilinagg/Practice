using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticeApp.Startup))]
namespace PracticeApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
