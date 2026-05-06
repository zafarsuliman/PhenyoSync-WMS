namespace PhenyoSyncAPI.Models
{
    public class WarehouseManager
    {
        public int WarehouseManagerId { get; set; }
        public int UserId { get; set; }

        public string ManagerCode { get; set; } = string.Empty;
        public string WarehouseSection { get; set; } = string.Empty;

        public User? User { get; set; }
    }
}
