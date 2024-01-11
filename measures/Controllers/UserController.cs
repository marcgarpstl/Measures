using Measure.Domain.DTOs.WriteDTO;
using Measure.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Measures.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IUserService _userService;

        public userController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all-users")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok();
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser(SetUserDto userDto, CancellationToken ct = default)
        {
            if (userDto == null)
            {
                return BadRequest("User info cannot be null");
            }
            try
            {
                await _userService.AddUserAsync(userDto, ct);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser()
        {
            return Ok();
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser()
        {
            return Ok();
        }
    }
}
