using Microsoft.AspNetCore.Mvc;

namespace PhenyoSyncAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok("Auth controller is working");
        }
    }
}