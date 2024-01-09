using FMA.Domain.Config;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;

namespace FMA.Application
{
    public class NotificationHub : Hub
    {
        private readonly SignalR _optionsSignalR;
        public NotificationHub(IOptions<SignalR> optionsSignalR)
        {
            _optionsSignalR = optionsSignalR.Value;
        }
        public async Task ReceiveNotification(string message)
        {
            await Clients.All.SendAsync(_optionsSignalR.Hub.Method.Name, message);
        }
    }
}
