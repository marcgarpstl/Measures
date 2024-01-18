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

        [HttpGet("get-user")]
        public async Task<IActionResult> GetUsers(Guid id, CancellationToken ct = default)
        {
            if(id == Guid.Empty) return BadRequest("Id is empty");

            var user = await _userService.GetById(id);
            return Ok(user);
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
                return StatusCode(499, "Request cancelled");
            }
            catch (Exception)
            {
                return StatusCode(406, "Something went wrong");
            }
        }

        [HttpPut("change-email")]
        public async Task<IActionResult> ChangeEmail(Guid guid, string email, CancellationToken ct = default)
        {
            try
            {
                await _userService.ChangeEmail(guid, email, ct);
                return Ok();
            }
            catch(ArgumentException)
            {
                return BadRequest();
            }
            catch(OperationCanceledException) when (ct.IsCancellationRequested)
            {
                return StatusCode(499);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(Guid guid, string password, CancellationToken ct = default)
        {
            try
            {
                await _userService.ChangePassword(guid, password, ct);
                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (OperationCanceledException) when (ct.IsCancellationRequested)
            {
                return StatusCode(499);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser(Guid id, CancellationToken ct = default)
        {
            try
            {
                await _userService.DeleteUser(id, ct);
                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (OperationCanceledException) when (ct.IsCancellationRequested)
            {
                return StatusCode(499);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }


        }
    }
}
