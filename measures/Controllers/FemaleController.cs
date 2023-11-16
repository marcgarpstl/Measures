using Microsoft.AspNetCore.Mvc;

namespace Measures.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class femaleController : ControllerBase
    {
        [HttpGet("get-measures")]
        public async Task<IActionResult> GetFemaleMeasures()
        {
            return Ok();
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
