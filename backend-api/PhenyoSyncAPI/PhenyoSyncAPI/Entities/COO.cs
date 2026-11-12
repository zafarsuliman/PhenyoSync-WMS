using System.ComponentModel.DataAnnotations;

namespace PhenyoSyncAPI.Entities
{
    public class COO
    {

        [Key]
        public int COOId { get; set; }

        public int UserId { get; set; }

        public string? OfficeNumber { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public User User { get; set; } = null!;
    }
}