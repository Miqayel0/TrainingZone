using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IUnitOfWork _unitOfWork;
        public GameHub(IGameRepository gameRepository, UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _gameRepository = gameRepository;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task GetMove(string gameId, int value, int row, int col, int player)
        {
            var game = await _gameRepository.GetById(gameId);
            string observerId;

            if (game.IsGameFinished || !game.IsGameStarted)
            {
                throw new Exception("Bad Request");
            }

            if (player == 1)
            {
                observerId = game.SecondPlayerId;
            }
            else
            {
                observerId = game.FirstPlayerId;
            }

            game.PlayedCoordinates.Add(new Core.Entities.Point { PlayerId = observerId, Value = value , CoordinateX = row, CoordinateY = col });
            await _unitOfWork.Complete();
            //var currentUserId = Context.UserIdentifier;
            await Clients.User(observerId).SendAsync("sendToPlayer", value, row, col);
        }


    }
}
