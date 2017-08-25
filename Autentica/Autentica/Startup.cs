using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autentica.Startup))]
namespace Autentica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
