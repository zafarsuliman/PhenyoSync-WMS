using System.ComponentModel.DataAnnotations;

namespace PhenyoSyncAPI.Entities
{
    public class Packer
    {

        [Key]
        public int PackerId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string PackingStation { get; set; } = string.Empty;

        [Required]
        public string Shift { get; set; } = string.Empty;

        public string? PackingArea { get; set; }

        public DateTime? EmploymentDate { get; set; }

        public User User { get; set; } = null!;
    }
}