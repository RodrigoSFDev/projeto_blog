using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApi.DataModel;
using BlogApi.DataModel.Interfaces;
using BlogApi.Services;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;

        public UserController(IUserService userService, IJWTAuthenticationManager jwtAuthenticationManager)
        {
            _userService = userService;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user, string password)
        {
            try
            {
                var newUser = await _userService.Register(user, password);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            try
            {
                var token = _jwtAuthenticationManager.Authenticate(email, password);

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized();
                }

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            try
            {
                var updatedUser = await _userService.Update(id, user);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}