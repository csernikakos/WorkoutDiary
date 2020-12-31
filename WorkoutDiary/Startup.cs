using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkoutDiary.Startup))]
namespace WorkoutDiary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
