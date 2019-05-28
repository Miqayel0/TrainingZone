using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingZone.Core.Auth.Users;
using TrainingZone.Core.Interfaces.Services;
using TrainingZone.Models.Requests;
using TrainingZone.Models.Response;

namespace TrainingZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly IMapper _mapper;

        public AuthController(UserManager<User> userManager, IJwtFactory jwtFactory, IMapper mapper)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _mapper = mapper;
        }
        // GET: api/Auth
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Auth/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Auth
        [HttpPost]
        public async Task<ActionResult> Login([FromForm] LoginRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.Password) || String.IsNullOrWhiteSpace(request.UserName))
            {
                return BadRequest("Invalid UserName or Password");
            }

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var accessToken = await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName);
                var userRespose = _mapper.Map<LoginResponse>(user);
                userRespose.AccessToken = accessToken;

                return Ok(userRespose);
            }
            else
            {
                return BadRequest("Invalid UserName or Password");
            }
        }

        // PUT: api/Auth/5
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
