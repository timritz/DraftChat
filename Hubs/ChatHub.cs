using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;

namespace DraftChat.Hubs
{
    public class ChatHub : Hub
    {
        
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task UpdateTimer(string counter)
        {
            await Clients.All.SendAsync("ReceiveTimer", counter);
        }
    }
}