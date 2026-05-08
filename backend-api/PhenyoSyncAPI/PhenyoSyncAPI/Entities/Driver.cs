using System.ComponentModel.DataAnnotations;

namespace PhenyoSyncAPI.Entities
{
    public class Driver
    {

        [Key]
        public int DriverId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string LicenseNumber { get; set; }

        public DateTime LicenseExpiryDate { get; set; }

        public string? VehicleAssigned { get; set; }

        [Required]
        public string AvailabilityStatus { get; set; }

        public User User { get; set; }
    }
}
