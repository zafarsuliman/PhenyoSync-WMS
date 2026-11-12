using System.ComponentModel.DataAnnotations;

namespace PhenyoSyncAPI.Entities
{
    public class Businessmanager
    {

        [Key]
        public int BusinessManagerId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Department { get; set; } = string.Empty;

        public string? OfficeNumber { get; set; }

        public string? ManagedSection { get; set; }

        public DateTime? EmploymentDate { get; set; }

        public User User { get; set; } = null!;
    }
}