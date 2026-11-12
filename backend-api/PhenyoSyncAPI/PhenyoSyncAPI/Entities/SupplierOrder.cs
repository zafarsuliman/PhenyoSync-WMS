using System.ComponentModel.DataAnnotations;

namespace PhenyoSyncAPI.Entities
{
    public class SupplierOrder
    {
        [Key]
        public int SupplierOrderId { get; set; }

        public int SupplierId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; }

        public Supplier Supplier { get; set; }
    }
}
