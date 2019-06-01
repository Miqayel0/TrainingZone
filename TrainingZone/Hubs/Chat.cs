using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingZone.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Chat : Hub
    {
        public async Task SendToAll(string userId, string message)
        {
            var name = Context.User.Identity.Name;
            await Clients.User(userId).SendAsync("sendToAll", name, message);
        }
    }
}
