using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingZone.Core.Auth.Users;
using TrainingZone.Core.Interfaces;

namespace TrainingZone.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GameHub : Hub
    {
        private readonly IGameRepository _gameRepository;
        private readonly UserManager<User> _userManager;
        public GameHub(IGameRepository gameRepository, UserManager<User> userManager)
        {
            _gameRepository = gameRepository;
            _userManager = userManager;
        }

        public async Task SendToAll(string userId, string message)
        {
            var currentUserId = Context.UserIdentifier;
            var name = Context.User.Identity.Name;
            await Clients.User(currentUserId).SendAsync("sendToAll", name, message);
        }
    }
}
