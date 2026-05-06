using Microsoft.AspNetCore.Mvc;

namespace PhenyoSyncAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok("Users endpoint working");
        }

        [HttpPost]
        public IActionResult CreateUser()
        {
            return Ok("Create user working");
        }
    }
}
