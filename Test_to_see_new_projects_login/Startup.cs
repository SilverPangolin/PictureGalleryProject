using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test_to_see_new_projects_login.Startup))]
namespace Test_to_see_new_projects_login
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
