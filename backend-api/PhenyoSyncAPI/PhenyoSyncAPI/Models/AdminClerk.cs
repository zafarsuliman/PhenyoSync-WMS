namespace PhenyoSyncAPI.Models
{
    public class AdminClerk
    {
        public int AdminClerkId { get; set; }
        public int UserId { get; set; }
        public string EmployeeNumber { get; set; } = string.Empty;
        public string AccessLevel { get; set; } = string.Empty;

        public User? User { get; set; }
    }
}
