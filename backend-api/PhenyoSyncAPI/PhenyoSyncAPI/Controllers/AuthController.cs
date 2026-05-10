using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhenyoSyncAPI.Data;
using PhenyoSyncAPI.Services;


namespace PhenyoSyncAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly PhenyoSyncDbContext _context;
        private readonly JwtService _jwt;
        public AuthController(PhenyoSyncDbContext context, JwtService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _context.Users
        .Include(u => u.Role)
        .FirstOrDefault(u => u.Email == dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials");

            var token = _jwt.GenerateToken(user);

            return Ok(new
            {
                token,
                user.UserId,
                user.Email,
                Role = user.Role.RoleName
            });
        }
    }
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
