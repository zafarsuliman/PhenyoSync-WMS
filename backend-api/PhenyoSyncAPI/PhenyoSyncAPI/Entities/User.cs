using System.ComponentModel.DataAnnotations;
using System.Data;

namespace PhenyoSyncAPI.Entities
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        public int RoleId { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        // Navigation
        public Role? Role { get; set; }
        public Driver Driver { get; set; }
        public ICollection<StockTakeSession> StockTakeSessions { get; set; }
    }
}
