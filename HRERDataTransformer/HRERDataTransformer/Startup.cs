using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRERDataTransformer.Startup))]
namespace HRERDataTransformer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
