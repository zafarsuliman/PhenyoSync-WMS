using Microsoft.AspNetCore.Mvc;
using PhenyoSyncAPI.Entities;
using Microsoft.EntityFrameworkCore;
using PhenyoSyncAPI.Data;

namespace PhenyoSyncAPI.Controllers
{
    [ApiController]
    [Route("api/permissions")]
    public class PermissionController : Controller
    {
        private readonly PhenyoSyncDbContext _context;

        public PermissionController(PhenyoSyncDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Permissions.ToList());
        }

        [HttpPost]
        public IActionResult Create(Permission permission)
        {
            _context.Permissions.Add(permission);
            _context.SaveChanges();
            return Ok(permission);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Permission updated)
        {
            var perm = _context.Permissions.Find(id);
            if (perm == null) return NotFound();

            perm.PermissionName = updated.PermissionName;
            _context.SaveChanges();

            return Ok(perm);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var perm = _context.Permissions.Find(id);
            if (perm == null) return NotFound();

            _context.Permissions.Remove(perm);
            _context.SaveChanges();

            return Ok();
        }
    }
}
