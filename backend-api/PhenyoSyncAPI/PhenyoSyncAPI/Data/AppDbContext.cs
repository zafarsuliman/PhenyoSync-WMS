using Microsoft.EntityFrameworkCore;
using PhenyoSyncAPI.Models;

namespace PhenyoSyncAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AdminClerk> AdminClerks { get; set; }
        public DbSet<WarehouseManager> WarehouseManagers { get; set; }
        public DbSet<Packer> Packers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<StockTaker> StockTakers { get; set; }
    }
}