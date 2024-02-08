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
        private readonly IUnitOfWork _unitOfWork;
        private IUserService _userService;

        public femaleController(IFemaleMeasureService femaleMeasureService, IUnitOfWork unitOfWork, IUserService userService)
        {
            _femaleMeasureService = femaleMeasureService;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        [HttpGet("get-measures")]
        public async Task<IActionResult> GetFemaleMeasures(Guid id, CancellationToken ct = default)
        {

            if (id == Guid.Empty) return BadRequest("Id is empty");

            var user = await _userService.GetById(id);

            if (user.Female == null) return BadRequest("No measures has been added");

            return Ok(user.Female);
        }

        [HttpPost("add-measures")]
        public async Task<IActionResult> AddFemaleMeasures(Guid id, SetFemaleMeasuresDto female, CancellationToken ct = default)
        {
            if (female == null) throw new ArgumentNullException(nameof(female));

            if (id == Guid.Empty) return BadRequest("No user found.");

            try
            {
                var user = await _userService.GetById(id, ct);

                var userFemale = await _femaleMeasureService.AddFemaleMeasureAsync(female, ct);

                user.Female = userFemale;

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
