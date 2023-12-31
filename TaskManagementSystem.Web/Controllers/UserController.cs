﻿using ApplicationShared.Dto.UserDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.ApplicationServices;
using TaskManagementSystem.Application.IApplicationServices;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController( IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var users = await _userAppService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> GetUser(int userId)
        {
            var user = await _userAppService.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserInput input)
        {
            if (input == null)
            {
                return BadRequest();
            }

            await _userAppService.CreateUser(input);
            return CreatedAtAction(nameof(GetUser), new {  }, input);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser( UpdateUserInput input)
        {
            if (input == null )
            {
                return BadRequest();
            }

            await _userAppService.UpdateUser(input);
            return NoContent();
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userAppService.DeleteUser(userId);
            return NoContent();
        }
    }
}
