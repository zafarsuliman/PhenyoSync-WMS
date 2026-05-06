using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhenyoSyncAPI.Data;
using PhenyoSyncAPI.Models;

namespace PhenyoSyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseManagersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WarehouseManagersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseManager>>> GetWarehouseManagers()
        {
            return await _context.WarehouseManagers.Include(w => w.User).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseManager>> GetWarehouseManager(int id)
        {
            var manager = await _context.WarehouseManagers.Include(w => w.User)
                .FirstOrDefaultAsync(w => w.WarehouseManagerId == id);

            if (manager == null) return NotFound();

            return manager;
        }

        [HttpPost]
        public async Task<ActionResult<WarehouseManager>> CreateWarehouseManager(WarehouseManager manager)
        {
            _context.WarehouseManagers.Add(manager);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWarehouseManager), new { id = manager.WarehouseManagerId }, manager);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarehouseManager(int id, WarehouseManager manager)
        {
            if (id != manager.WarehouseManagerId) return BadRequest();

            _context.Entry(manager).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouseManager(int id)
        {
            var manager = await _context.WarehouseManagers.FindAsync(id);

            if (manager == null) return NotFound();

            _context.WarehouseManagers.Remove(manager);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
