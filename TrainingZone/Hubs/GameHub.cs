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
using TrainingZone.Core.Entities;
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

        public async Task GetMove(string gameId, int value, int row, int col)
        {
            var game = await _gameRepository.GetById(gameId);
            var currentUserId = Context.UserIdentifier;
            int player = 0;
            string observerId;

            if (game.IsGameFinished || !game.IsGameStarted)
            {
                throw new Exception();
            }

            if (currentUserId == game.FirstPlayerId)
            {
                player = 1;
            }
            else if (currentUserId == game.SecondPlayerId)
            {
                player = 2;
            }

            switch (player)
            {
                case 1:
                    observerId = game.SecondPlayerId;
                    game.CurrentTurn = 2;
                    break;

                case 2:
                    observerId = game.FirstPlayerId;
                    game.CurrentTurn = 1;
                    break;
                default:
                    throw new UnauthorizedAccessException();
            }

            game.PlayedCoordinates.Add(new Point
            {
                PlayerId = observerId,
                Value = value,
                CoordinateX = row,
                CoordinateY = col
            });

            await _unitOfWork.Complete();
            await Clients.User(observerId).SendAsync("sendToPlayer", value, row, col);
        }

    }
}
