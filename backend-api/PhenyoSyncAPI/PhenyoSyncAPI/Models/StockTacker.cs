namespace PhenyoSyncAPI.Models
{
    public class StockTaker
    {
        public int StockTakerId { get; set; }
        public int UserId { get; set; }

        public string AssignedWarehouseZone { get; set; } = string.Empty;
        public DateTime LastStockTakeDate { get; set; }
        public decimal AccuracyScore { get; set; }

        public User? User { get; set; }
    }
}
