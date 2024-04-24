using Measure.Domain.DTOs.WriteDTO;
using Measure.Domain.Entities;
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

        public femaleController(IFemaleMeasureService femaleMeasureService, IUserService userService)
        {
            _femaleMeasureService = femaleMeasureService;
        }

        [HttpGet("get-measures")]
        public async Task<IActionResult> GetFemaleMeasures(Guid id, CancellationToken ct = default)
        {

            if (id == Guid.Empty) return BadRequest("Id is empty");

            var female = await _femaleMeasureService.GetFemaleMeasureAsync(id);

            if (female == null) return BadRequest("Female Id not found");

            return Ok(female);
        }

        [HttpPut("add-measures")]
        public async Task<IActionResult> AddFemaleMeasures(Guid id, SetFemaleMeasuresDto femaleDto, CancellationToken ct = default)
        {
            if (femaleDto == null) throw new ArgumentNullException(nameof(femaleDto));

            if (id == Guid.Empty) return BadRequest("No user found.");

            try
            {
                await _femaleMeasureService.AddFemaleMeasureAsync(id, femaleDto, ct);

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
            catch (Exception) 
            {
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
