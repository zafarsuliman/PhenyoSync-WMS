using Microsoft.AspNetCore.Mvc;
using PhenyoSyncAPI.Entities;
using PhenyoSyncAPI.Data;

namespace PhenyoSyncAPI.Controllers
{
    public class StockController : Controller
    {
        private readonly PhenyoSyncDbContext _context;

        public StockController(PhenyoSyncDbContext context)
        {
            _context = context;
        }

        [HttpPost("session")]
        public IActionResult StartSession(StockTakeSession session)
        {
            _context.StockTakeSessions.Add(session);
            _context.SaveChanges();
            return Ok(session);
        }

        [HttpGet("session")]
        public IActionResult GetSessions()
        {
            return Ok(_context.StockTakeSessions.ToList());
        }
    }
}
