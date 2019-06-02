using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingZone.Core.Interfaces;

namespace TrainingZone.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GameHub : Hub
    {
        private readonly IScoreRepository _scoreRepository;
        public GameHub(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        public async Task SendToAll(string userId, string message)
        {
            var currentUserId = Context.UserIdentifier;
            var scors = await _scoreRepository.GetByPlayerId(userId);
            var name = Context.User.Identity.Name;
            await Clients.User(userId).SendAsync("sendToAll", name, message);
        }
    }
}
