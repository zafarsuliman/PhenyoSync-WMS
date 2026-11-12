using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PhenyoSyncAPI.Entities
{
    public class AdminClerk
    {
        [Key]
        public int AdminClerkId { get; set; }

        public int UserId { get; set; }

        public string EmployeeNumber { get; set; }
        public string AccessLevel { get; set; }

        public bool IsActive { get; set; } = true;

        public string AssignedCustomerPortfolio { get; set; }

        public bool CanRecordProcurementInvoices { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
