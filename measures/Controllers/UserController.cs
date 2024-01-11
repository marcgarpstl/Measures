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
                throw new ArgumentNullException(nameof(userDto));
            } 
            try
            {
                await _userService.AddUserAsync(userDto, ct);
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid argument");
            }
            catch (OperationCanceledException) when (ct.IsCancellationRequested)
            {
                return StatusCode(204, "Request cancelled");
            }
            catch (Exception)
            {
                return StatusCode(406, "Something went wrong");
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
