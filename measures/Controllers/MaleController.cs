using Microsoft.AspNetCore.Mvc;

namespace Measures.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class maleController : ControllerBase
    {
        [HttpGet("get-measures")]
        public async Task<IActionResult> GetMaleMeasures()
        {
            return Ok();
        }

        [HttpPost("add-measures")]
        public async Task<IActionResult> AddMaleMeasures()
        {
            return Ok();
        }

        [HttpPut("update-measures")]
        public async Task<IActionResult> UpdateMaleMeasures()
        {
            return Ok();
        }

        [HttpDelete("delete-measures")]
        public async Task<IActionResult> DeleteMaleMeasures()
        {
            return Ok();
        }
    }
}
