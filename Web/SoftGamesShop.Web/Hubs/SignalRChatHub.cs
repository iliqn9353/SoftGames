namespace SoftGamesShop.Web.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using SoftGamesShop.Data.Models;
    
    [Authorize]
    public class SignalRChatHub:Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new ChatMessage { User = this.Context.User.Identity.Name.Split('@')[0], Text = message, });
        }
    }
}
