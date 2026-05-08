using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhenyoSyncAPI.Data;
using PhenyoSyncAPI.Models;

namespace PhenyoSyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTakersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StockTakersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockTaker>>> GetStockTakers()
        {
            return await _context.StockTakers.Include(s => s.User).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockTaker>> GetStockTaker(int id)
        {
            var stockTaker = await _context.StockTakers.Include(s => s.User)
                .FirstOrDefaultAsync(s => s.StockTakerId == id);

            if (stockTaker == null) return NotFound();

            return stockTaker;
        }

        [HttpPost]
        public async Task<ActionResult<StockTaker>> CreateStockTaker(StockTaker stockTaker)
        {
            _context.StockTakers.Add(stockTaker);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStockTaker), new { id = stockTaker.StockTakerId }, stockTaker);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStockTaker(int id, StockTaker stockTaker)
        {
            if (id != stockTaker.StockTakerId) return BadRequest();

            _context.Entry(stockTaker).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockTaker(int id)
        {
            var stockTaker = await _context.StockTakers.FindAsync(id);

            if (stockTaker == null) return NotFound();

            _context.StockTakers.Remove(stockTaker);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
