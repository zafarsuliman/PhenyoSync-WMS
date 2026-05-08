using Microsoft.AspNetCore.Mvc;
using PhenyoSyncAPI.Entities;
using PhenyoSyncAPI.Data;

namespace PhenyoSyncAPI.Controllers
{
    [ApiController]
    [Route("api/suppliers")]
    public class SupplierController : Controller
    {
        private readonly PhenyoSyncDbContext _context;

        public SupplierController(PhenyoSyncDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Suppliers.ToList());
        }

        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return Ok(supplier);
        }
    }
}
