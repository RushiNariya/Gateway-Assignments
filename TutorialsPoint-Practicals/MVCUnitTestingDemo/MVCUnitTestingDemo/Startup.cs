using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCUnitTestingDemo.Startup))]
namespace MVCUnitTestingDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
