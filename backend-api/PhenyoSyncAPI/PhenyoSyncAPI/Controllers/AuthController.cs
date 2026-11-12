using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhenyoSyncAPI.Data;
using PhenyoSyncAPI.Services;

namespace PhenyoSyncAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
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
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                {
                    return BadRequest("Email and password are required");
                }

                var user = _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Email == dto.Email);

                if (user == null)
                {
                    return Unauthorized("User not found");
                }

                bool isPasswordValid = false;

                try
                {
                    isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
                }
                catch
                {
                    isPasswordValid = user.PasswordHash == dto.Password;
                }

                if (!isPasswordValid)
                {
                    return Unauthorized("Password incorrect");
                }

                if (string.IsNullOrEmpty(user.Status))
                {
                    return Unauthorized("Status is null");
                }

                if (user.Status.ToLower() != "active")
                {
                    return Unauthorized("User inactive");
                }

                var token = _jwt.GenerateToken(user);

                return Ok(new
                {
                    token = token,
                    userId = user.UserId,
                    email = user.Email,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    role = user.Role != null ? user.Role.RoleName : "Unknown"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}