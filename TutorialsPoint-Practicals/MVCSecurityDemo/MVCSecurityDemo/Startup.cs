using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSecurityDemo.Startup))]
namespace MVCSecurityDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
