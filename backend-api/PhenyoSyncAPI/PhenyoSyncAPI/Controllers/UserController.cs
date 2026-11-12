using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhenyoSyncAPI.Data;
using PhenyoSyncAPI.Entities;

namespace PhenyoSyncAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly PhenyoSyncDbContext _context;

        public UserController(PhenyoSyncDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users
                .Include(u => u.Role)
                .Select(u => new {
                    u.UserId,
                    u.Email,
                    u.FirstName,
                    u.LastName,
                    Role = u.Role.RoleName
                })
                .ToList();

            return Ok(users);
        }

        [HttpGet("role/{roleName}")]
        public IActionResult GetByRole(string roleName)
        {
            var users = _context.Users
                .Include(u => u.Role)
                .Where(u => u.Role.RoleName == roleName)
                .Select(u => new {
                    u.UserId,
                    u.Email,
                    u.FirstName,
                    u.LastName
                })
                .ToList();

            return Ok(users);
        }

        [HttpPost]
        public IActionResult Create(UserCreateDto dto)
        {
            var user = new User
            {
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                RoleId = dto.RoleId,
                Status = "Active"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserUpdateDto dto)
        {
            var user = _context.Users.Find(id);

            if (user == null)
                return NotFound();

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.RoleId = dto.RoleId;
            user.Status = dto.Status;

            _context.SaveChanges();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok();
        }
    }
    public class UserCreateDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
    }
    public class UserUpdateDto
    {
        public string Email { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int RoleId { get; set; }

        public string Status { get; set; } = "Active";
    }
}
