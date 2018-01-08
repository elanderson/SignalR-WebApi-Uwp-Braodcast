using System;
using Windows.UI.Xaml.Controls;
using Microsoft.AspNet.SignalR.Client;
using System.ComponentModel;
using Windows.UI.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            InitilizeHub();
        }

        private async void InitilizeHub()
        {
            var hubConnection = new HubConnection("http://localhost:50869");
            var hubProxy = hubConnection.CreateHubProxy("BroadcastHub");

            hubProxy.On<DateTime>("Broadcast",
                                  async data => await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                                                                          () => BroadcastResults.Text = data.ToString()));
            await hubConnection.Start();
        }
    }
}
