using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhenyoSyncAPI.Data;
using PhenyoSyncAPI.Models;

namespace PhenyoSyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminClerksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminClerksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminClerk>>> GetAdminClerks()
        {
            return await _context.AdminClerks.Include(a => a.User).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminClerk>> GetAdminClerk(int id)
        {
            var clerk = await _context.AdminClerks.Include(a => a.User)
                .FirstOrDefaultAsync(a => a.AdminClerkId == id);

            if (clerk == null) return NotFound();

            return clerk;
        }

        [HttpPost]
        public async Task<ActionResult<AdminClerk>> CreateAdminClerk(AdminClerk clerk)
        {
            _context.AdminClerks.Add(clerk);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdminClerk), new { id = clerk.AdminClerkId }, clerk);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdminClerk(int id, AdminClerk clerk)
        {
            if (id != clerk.AdminClerkId) return BadRequest();

            _context.Entry(clerk).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminClerk(int id)
        {
            var clerk = await _context.AdminClerks.FindAsync(id);

            if (clerk == null) return NotFound();

            _context.AdminClerks.Remove(clerk);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
