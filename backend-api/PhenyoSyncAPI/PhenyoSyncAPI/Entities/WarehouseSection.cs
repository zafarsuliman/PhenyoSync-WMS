using System.ComponentModel.DataAnnotations;

namespace PhenyoSyncAPI.Entities
{
    public class WarehouseSection
    {
        [Key]
        public int SectionId { get; set; }

        [Required]
        public string SectionName { get; set; }

        public string? Description { get; set; }

        [Required]
        public string Status { get; set; }

        public ICollection<Stock> Stocks { get; set; }
        public ICollection<StockTakeSession> StockTakeSessions { get; set; }
    }
}
