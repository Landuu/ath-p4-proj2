using ath_p4_proj2.Models;
using Microsoft.EntityFrameworkCore;

namespace ath_p4_proj2.Database
{
    internal class InventoryDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceHistory> DeviceHistories { get; set; }
        public DbSet<DeviceMalfunction> DeviceMalfunctions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WB_Proj2;Integrated Security=True;
                                        Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
