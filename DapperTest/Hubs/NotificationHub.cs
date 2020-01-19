using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace DapperTest.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task NotifyClients()
        {
            await Clients.All.SendAsync("ClientSideFunction", "Message to all Clients");
        }
    }
}
