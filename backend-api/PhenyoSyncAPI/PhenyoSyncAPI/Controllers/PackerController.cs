using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhenyoSyncAPI.Data;
using PhenyoSyncAPI.Models;

namespace PhenyoSyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PackersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Packer>>> GetPackers()
        {
            return await _context.Packers.Include(p => p.User).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Packer>> GetPacker(int id)
        {
            var packer = await _context.Packers.Include(p => p.User)
                .FirstOrDefaultAsync(p => p.PackerId == id);

            if (packer == null) return NotFound();

            return packer;
        }

        [HttpPost]
        public async Task<ActionResult<Packer>> CreatePacker(Packer packer)
        {
            _context.Packers.Add(packer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPacker), new { id = packer.PackerId }, packer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePacker(int id, Packer packer)
        {
            if (id != packer.PackerId) return BadRequest();

            _context.Entry(packer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacker(int id)
        {
            var packer = await _context.Packers.FindAsync(id);

            if (packer == null) return NotFound();

            _context.Packers.Remove(packer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
