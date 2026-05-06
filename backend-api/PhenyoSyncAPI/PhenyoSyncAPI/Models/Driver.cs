namespace PhenyoSyncAPI.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        public int UserId { get; set; }

        public string LicenseNumber { get; set; } = string.Empty;
        public string VehicleAssigned { get; set; } = string.Empty;
        public string AvailabilityStatus { get; set; } = string.Empty;

        public User? User { get; set; }
    }
}
