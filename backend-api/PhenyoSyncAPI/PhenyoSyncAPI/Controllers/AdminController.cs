using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace PhenyoSyncAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : Controller
    {
        [Authorize(Roles = "AdminClerk")]
        [HttpGet("dashboard")]
        public IActionResult AdminDashboard()
        {
            return Ok("Welcome Admin Clerk");
        }
    }
}
