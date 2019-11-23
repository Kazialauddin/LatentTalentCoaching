using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(w1.Startup))]
namespace w1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
