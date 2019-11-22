using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(SeaBattle.Client.Startup))]
namespace SeaBattle.Client
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.MapSignalR();
        }
    }
}