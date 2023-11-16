using Microsoft.AspNetCore.Mvc;

namespace Measures.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        [HttpGet("all-users")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok();
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser()
        {
            return Ok();
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
