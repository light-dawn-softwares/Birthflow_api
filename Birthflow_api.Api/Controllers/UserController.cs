using Birthflow_api.Application.Dto;
using Birthflow_api.Application.Interfaces;
using Birthflow_api.Application.Services;
using Birthflow_api.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Birthflow_api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(Guid userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);

                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            try
            {
                _userService.CreateUser(user);
                return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(Guid userId, [FromBody] UserDto user)
        {
            try
            {
                var existingUser = _userService.GetUserById(userId);

                if (existingUser == null)
                    return NotFound();


                _userService.UpdateUser(user);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(Guid userId)
        {
            try
            {
                var existingUser = _userService.GetUserById(userId);

                if (existingUser == null)
                    return NotFound();

                _userService.DeleteUser(userId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
