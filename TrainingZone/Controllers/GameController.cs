using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingZone.Core.Auth.Users;
using TrainingZone.Core.Entities;
using TrainingZone.Core.Interfaces;
using TrainingZone.Models.Dtos;
using TrainingZone.Models.Requests;
using TrainingZone.Models.Response;

namespace TrainingZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public GameController(UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper, IGameRepository gameRepository)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        // GET: api/Game

        [HttpGet]
        public string[] Get()
        {
            return new string[] { "value", "value2" };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameResponse>> Get(string id)
        {
            var game = await _gameRepository.GetById(id);
            if (game == null)
            {
                return BadRequest("Game is not exist");
            }

            var gameResponse = _mapper.Map<GameResponse>(game);
            gameResponse.Moves = _mapper.Map<ICollection<MoveDto>>(game.PlayedCoordinates);

            return gameResponse;
        }

        [HttpGet]
        [Route("player-number/{gameId}")]
        public async Task<ActionResult<GameResponse>> GetPlayerNumber(string gameId)
        {
            const int firstPlayerNum = 1;
            const int secondPlayerNum = 2;
            var game = await _gameRepository.GetById(gameId);
            var user = await _userManager.GetUserAsync(User);

            if (game is null || user is null)
            {
                return BadRequest();
            }

            if (game.FirstPlayerId == user.Id)
            {
                return Ok(new PlayerNumberResponse { Player = firstPlayerNum });
            }
            else if (game.SecondPlayerId == user.Id)
            {
                return Ok(new PlayerNumberResponse { Player = secondPlayerNum });
            }

            return BadRequest();
        }

        // POST: api/Game
        [HttpPost]
        public async Task<ActionResult<CreateGameResponse>> Create([FromForm] CreateGameRequest request)
        {
            var gameConfig = _mapper.Map<Game>(request);
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound("Player not found");
            }

            switch (request.FirstPlayerTurn)
            {
                case 1:
                    gameConfig.SecondPlayerTurn = 2; // O
                    gameConfig.CurrentTurn = 1;
                    break;
                case 2:
                    gameConfig.SecondPlayerTurn = 1; // X
                    gameConfig.CurrentTurn = 2;
                    break;
                default:
                    return BadRequest("Player turn not selected");
            }

            gameConfig.FirstPlayerId = user.Id;
            gameConfig.FirstPlayerTurn = request.FirstPlayerTurn;

            await _gameRepository.Add(gameConfig);
            await _unitOfWork.Complete();

            return Ok(new CreateGameResponse { GameId = gameConfig.Id.ToString() });
        }

        [HttpPost]
        [Route("attach-player")]
        public async Task<ActionResult> AttachSecondPlayer([FromForm] AttachSecondPlayerToGameRequset requset)
        {
            var game = await _gameRepository.GetById((requset.GameId));
            if (game == null)
            {
                return NotFound("Game not found");
            }

            if (game.IsGameFinished)
            {
                return BadRequest("You are trying to connect finished game");
            }

            if (game.SecondPlayerId != null && game.IsGameStarted)
            {
                return Ok(new CreateGameResponse { GameId = game.Id.ToString() });
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound("Player not found");
            }

            game.SecondPlayerId = user.Id;
            game.IsGameStarted = true;

            try
            {
                await _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok(new CreateGameResponse { GameId = game.Id.ToString() });
        }

        // PUT: api/Game/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
