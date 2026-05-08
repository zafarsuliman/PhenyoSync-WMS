using System.ComponentModel.DataAnnotations;

namespace PhenyoSyncAPI.Entities
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        public int ProductId { get; set; }

        public int SectionId { get; set; }

        public decimal QuantityAvailableKg { get; set; }

        public decimal ReorderLevelKg { get; set; }

        public string InventoryStatus { get; set; }

        public WarehouseSection WarehouseSection { get; set; }
    }
}
