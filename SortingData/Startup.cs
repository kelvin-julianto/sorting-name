using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SortingData.Startup))]
namespace SortingData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
