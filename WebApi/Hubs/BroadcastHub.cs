using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApi.Hubs
{
    [HubName("BroadcastHub")]
    public class BroadcastHub : Hub
    {
        private readonly Broadcaster _broadcaster = Broadcaster.Instance;
    }
}