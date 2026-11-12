using System.ComponentModel.DataAnnotations;

namespace PhenyoSyncAPI.Entities
{
    public class Warehousemanager
    {

        [Key]
        public int WarehouseManagerId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string WarehouseSection { get; set; } = string.Empty;

        public string? OfficeNumber { get; set; }

        public DateTime? EmploymentDate { get; set; }

        public User User { get; set; } = null!;
    }
}