using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingZone.Core.Auth.Users;
using TrainingZone.Core.Entities;
using TrainingZone.Core.Interfaces;
using TrainingZone.Models.Requests;
using TrainingZone.Models.Response;

namespace TrainingZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var gameResponse = _mapper.Map<GameResponse>(game);
            return gameResponse;
        }

        // POST: api/Game
        [HttpPost]
        public async Task<ActionResult<CreateGameResponse>> Create([FromForm] CreateGameRequest request)
        {
            var gameConfig = _mapper.Map<Game>(request);
            await _gameRepository.Add(gameConfig);
            await _unitOfWork.Complete();

            return Ok(new CreateGameResponse { GameId = gameConfig.Id.ToString() });
        }

        [HttpPost]
        [Route("attach-player")]
        public async Task<ActionResult> AttachSecondPlayer([FromForm] AttachSecondPlayerToGameRequset requset)
        {
            var game = await _gameRepository.GetById(requset.GameId);
            if(game == null)
            {
                return NotFound("Game not found");
            }

            string userId = (await _userManager.GetUserAsync(User)).Id;

            if(userId == null)
            {
                return NotFound("Player not found");
            }

            game.SecondPlayerId = userId;

            try
            {
                await _unitOfWork.Complete();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok("Player Was Successful Attached");
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
