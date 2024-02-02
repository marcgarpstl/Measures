using Measure.Domain.DTOs.WriteDTO;
using Measure.Domain.Repositories;
using Measure.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Measures.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class femaleController : ControllerBase
    {
        private readonly IFemaleMeasureService _femaleMeasureService;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public femaleController(IFemaleMeasureService femaleMeasureService, IUserRepository userRepository)
        {
            _femaleMeasureService = femaleMeasureService;
            _userRepository = userRepository;
        }

        [HttpGet("get-measures")]
        public async Task<IActionResult> GetFemaleMeasures(Guid id, CancellationToken ct = default)
        {
            if (id == Guid.Empty) return BadRequest("Id is empty");

            var user = await _userRepository.GetUserByGuidAsync(id);

            return Ok(user.Female);

        }

        [HttpPost("add-measures")]
        public async Task<IActionResult> AddFemaleMeasures(Guid id, SetFemaleMeasuresDto female, CancellationToken ct = default)
        {
            if (female == null) throw new ArgumentNullException(nameof(female));

            try
            {
                var user = await _userRepository.GetUserByGuidAsync(id, ct);

                if (user == null) return BadRequest("No user found.");

                user.Female = await _femaleMeasureService.AddFemaleMeasureAsync(id, female, ct);

                return Ok("Female measures added.");
            }
            catch(ArgumentException)
            {
                return BadRequest("Invalid argument.");
            }
            catch(OperationCanceledException) when (ct.IsCancellationRequested) 
            {
                return StatusCode(499, "Request cancelled.");
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "This is my error.");
                return StatusCode(500);
            }
            
        }

        [HttpPut("update-measures")]
        public async Task<IActionResult> UpdateFemaleMeasures()
        {
            return Ok();
        }

        [HttpDelete("delete-measures")]
        public async Task<IActionResult> DeleteFemaleMeasures()
        {
            return Ok();
        }
    }
}
