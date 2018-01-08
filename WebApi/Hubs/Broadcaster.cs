using System;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApi.Hubs
{
    public class Broadcaster
    {
        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(250);
        private Timer _timer;

        private static readonly Lazy<Broadcaster> _instance = new Lazy<Broadcaster>(() => new Broadcaster(GlobalHost.ConnectionManager.GetHubContext<BroadcastHub>().Clients));
        public static Broadcaster Instance => _instance.Value;

        public IHubConnectionContext<dynamic> Clients { get; set; }

        public Broadcaster(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            _timer = new Timer(Broadcast, null, _updateInterval, _updateInterval);
        }

        public void Broadcast(object state)
        {
            Clients.All.Broadcast(DateTime.Now);
        }
    }
}