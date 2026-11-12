using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhenyoSyncAPI.Data;
using PhenyoSyncAPI.Entities;

namespace PhenyoSyncAPI.Controllers
{
    [ApiController]
    [Route("api/drivers")]
    public class DriverController : Controller
    {
        private readonly PhenyoSyncDbContext _context;

        public DriverController(PhenyoSyncDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Driver dto)
        {
            _context.Drivers.Add(dto);
            _context.SaveChanges();
            return Ok(dto);
        }

        [Authorize(Roles = "Driver")]
        [HttpGet("jobs")]
        public IActionResult GetDriverJobs()
        {
            return Ok("Driver jobs loaded");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var drivers = _context.Drivers
                .Include(d => d.User)
                .Select(d => new {
                    d.DriverId,
                    d.LicenseNumber,
                    d.VehicleAssigned,
                    d.AvailabilityStatus,
                    d.User.FirstName,
                    d.User.LastName
                })
                .ToList();

            return Ok(drivers);
        }
    }
}
