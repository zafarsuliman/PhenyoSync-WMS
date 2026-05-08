using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhenyoSyncAPI.Data;

namespace PhenyoSyncAPI.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : Controller
    {
        private readonly PhenyoSyncDbContext _context;
        public TestController(PhenyoSyncDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TestDb()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }
}
