using Microsoft.AspNetCore.Mvc;
using Measure.Domain.Services;

namespace Measures.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokenHandlerController : ControllerBase
    {
        private readonly ITokenHandlerService _tokenHandlerService;

        public TokenHandlerController(ITokenHandlerService tokenHandlerService)
        {
            _tokenHandlerService = tokenHandlerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetToken([FromHeader(Name = "Authorization")] string token, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentNullException(nameof(token));
            }
            try
            {
                var userId = await _tokenHandlerService.HandleTokenAsync(token);
                return Ok(userId);
            }
            catch(OperationCanceledException)
            {
                return StatusCode(404);
            }
        }
    }
}
