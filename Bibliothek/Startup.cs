using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bibliothek.Startup))]
namespace Bibliothek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
