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
        public async Task<IActionResult> AddFemaleMeasures()
        {
            return Ok();
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
