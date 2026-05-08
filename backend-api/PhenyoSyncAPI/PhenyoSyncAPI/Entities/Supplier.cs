using System.ComponentModel.DataAnnotations;

namespace PhenyoSyncAPI.Entities
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        public string SupplierName { get; set; }

        public string? ContactPerson { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        [Required]
        public string Status { get; set; }

        public ICollection<SupplierOrder> SupplierOrders { get; set; }
    }
}
