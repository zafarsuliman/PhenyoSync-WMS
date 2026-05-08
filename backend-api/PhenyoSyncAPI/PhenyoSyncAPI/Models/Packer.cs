namespace PhenyoSyncAPI.Models
{
    public class Packer
    {
        public int PackerId { get; set; }
        public int UserId { get; set; }

        public string Shift { get; set; } = string.Empty;
        public string AssignedSection { get; set; } = string.Empty;

        public User? User { get; set; }
    }
}
