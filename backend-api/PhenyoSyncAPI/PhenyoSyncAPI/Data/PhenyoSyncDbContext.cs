using Microsoft.EntityFrameworkCore;
using PhenyoSyncAPI.Entities;
using System.Data;
using System.Security;

namespace PhenyoSyncAPI.Data
{
   public class PhenyoSyncDbContext : DbContext
    {
        public PhenyoSyncDbContext(DbContextOptions<PhenyoSyncDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<WarehouseSection> WarehouseSections { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierOrder> SupplierOrders { get; set; }
        public DbSet<StockTakeSession> StockTakeSessions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<RolePermission>()
      .HasKey(rp => new { rp.RoleId, rp.PermissionId });
        }
    }
}
