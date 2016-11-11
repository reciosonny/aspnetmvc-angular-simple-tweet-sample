using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleTweetApp.PureMVC.Startup))]
namespace SampleTweetApp.PureMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
