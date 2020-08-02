using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LEATS_Project.Startup))]
namespace LEATS_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
