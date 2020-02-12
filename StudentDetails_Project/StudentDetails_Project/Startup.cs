using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentDetails_Project.Startup))]
namespace StudentDetails_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
