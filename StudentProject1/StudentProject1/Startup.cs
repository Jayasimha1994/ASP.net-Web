using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentProject1.Startup))]
namespace StudentProject1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
