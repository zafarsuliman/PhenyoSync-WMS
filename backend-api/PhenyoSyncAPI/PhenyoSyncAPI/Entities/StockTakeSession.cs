using System.ComponentModel.DataAnnotations;

namespace PhenyoSyncAPI.Entities
{
    public class StockTakeSession
    {
        [Key]
        public int SessionId { get; set; }

        public int UserId { get; set; }

        public int SectionId { get; set; }

        public DateTime SessionDate { get; set; } = DateTime.Now;

        [Required]
        public string Status { get; set; }

        public string? Notes { get; set; }

        public User User { get; set; }
        public WarehouseSection WarehouseSection { get; set; }
    }
}
