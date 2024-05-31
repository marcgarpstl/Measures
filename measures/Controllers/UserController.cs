using FluentValidation;
using Measure.Domain.DTOs.WriteDTO;
using Measure.Domain.Services;
using Measure.Domain.Validators;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Measures.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserValidator _userValidator;
        private readonly IAdministrationService _administrationService;

        public UserController(IUserService userService, IUserValidator userValidator, IAdministrationService administrationService)
        {
            _userService = userService;
            _userValidator = userValidator;
            _administrationService = administrationService;
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers(CancellationToken ct = default)
        {
            try
            {
                var users = await _userService.GetAll(ct);

                return Ok(users);
            }
            catch (OperationCanceledException) when (ct.IsCancellationRequested)
            {
                return BadRequest();
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get-user")]
        public async Task<IActionResult> GetUser(Guid id, CancellationToken ct = default)
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
                var validationResult = _userValidator.Validating(userDto);

                if (validationResult != ValidationResult.Success) { return BadRequest(validationResult); }

                await _administrationService.AddAuthUser(userDto, ct);

                return Ok("User added successfully");
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
                return StatusCode(500, "Unknown");
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
