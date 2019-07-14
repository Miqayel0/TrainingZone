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
using TrainingZone.Utils;

namespace TrainingZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreRepository _scoreRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public ScoreController(UserManager<User> userManager, IScoreRepository scoreRepository, IUnitOfWork unitOfWork, IMapper mapper, IGameRepository gameRepository)
        {
            _scoreRepository = scoreRepository;
            _userManager = userManager;
            _gameRepository = gameRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET By User: api/Score
        [HttpGet]
        public async Task<ActionResult<ScoreResponse>> Get()
        {
            var player = await _userManager.GetUserAsync(User);

            if (player is null)
            {
                return BadRequest("The player doesn't exist");
            }

            var scores = await _scoreRepository.GetByPlayerId(player.Id);

            var response = _mapper.Map<ScoreResponse>(player);
            response.ScoreHistory = _mapper.Map<IEnumerable<ScoreHistoryDto>>(scores);

            return Ok(response);
        }

        // POST: api/Score
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ScoreRequest requset)
        {
            if (!requset.Winner.HasValue)
            {
                return BadRequest();
            }

            var firstPlayer = await _userManager.GetUserAsync(User);
            var secondPlayer = (await _gameRepository.GetById(requset.GameId)).SecondPlayer;

            if (firstPlayer is null || secondPlayer is null)
            {
                return BadRequest("Player not found");
            }

            firstPlayer.GamesCount++;
            secondPlayer.GamesCount++;

            switch (requset.Winner.Value)
            {
                case 0:
                    firstPlayer.Victories++;
                    secondPlayer.Losses++;
                    break;
                case 1:
                    secondPlayer.Victories++;
                    firstPlayer.Losses++;
                    break;
                default:
                    return BadRequest();
            }

            try
            {
                await _scoreRepository.Add(new Score
                {
                    FirstPlayerId = firstPlayer.Id,
                    SecondPlayerId = secondPlayer.Id,
                    Winner = requset.Winner
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            await _unitOfWork.Complete();
            return Ok();
        }

        // PUT: api/Score/5
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
