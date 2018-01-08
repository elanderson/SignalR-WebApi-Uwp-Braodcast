using Microsoft.AspNet.SignalR;
using Owin;

namespace WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConfiguration = new HubConfiguration
            {
                EnableDetailedErrors = true,
                EnableJavaScriptProxies = false
            };
            app.MapSignalR(hubConfiguration);

        }
    }
}