using System.ComponentModel.DataAnnotations;

namespace PhenyoSyncAPI.Entities
{
    public class Stocktaker
    {

        [Key]
        public int StockTakerId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string AssignedSection { get; set; } = string.Empty;

        [Required]
        public string Shift { get; set; } = string.Empty;

        public DateTime? LastStockTakeDate { get; set; }

        public User User { get; set; } = null!;
    }
}