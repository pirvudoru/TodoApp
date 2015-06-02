using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TodoUi.Startup))]
namespace TodoUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
