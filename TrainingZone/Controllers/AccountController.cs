﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingZone.Core.Auth.Users;
using TrainingZone.Models.Requests;
using TrainingZone.Models.Response;

namespace TrainingZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        // GET: api/Account
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Authorize]
        [HttpGet]
        [Route("player")]
        public async Task<ActionResult<UserResponse>> GetUser()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("Player Not Found");
            } 

            var response = _mapper.Map<UserResponse>(user);
            return Ok(response);
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        [HttpPost]
        public async Task<ActionResult> Register([FromForm] RegisterRequest request)
        {
            if (!ModelState.IsValid || String.IsNullOrWhiteSpace(request.Password) || String.IsNullOrWhiteSpace(request.UserName))
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(request);

            var result = await _userManager.CreateAsync(user, request.Password);
            return result.Succeeded ? Ok(result) : (ActionResult)BadRequest(result.Errors);
        }

        // PUT: api/Account/5
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Put([FromForm] UpdateUserRequest request)
        {
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                return NotFound("Player Not Found");
            }

           _mapper.Map(request, user);
            await _userManager.UpdateAsync(user);
            var updatedUser = _mapper.Map<UserResponse>(user);
            return Ok(updatedUser);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
