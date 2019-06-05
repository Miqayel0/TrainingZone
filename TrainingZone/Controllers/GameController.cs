using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingZone.Core.Auth.Users;
using TrainingZone.Core.Interfaces;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Game/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Game
        [HttpPost]
        public void Create([FromBody] CreateGameRequest request)
        {

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
