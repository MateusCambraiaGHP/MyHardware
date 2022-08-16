using Microsoft.EntityFrameworkCore;
using MyHardware.Interfaces;
using MyHardware.Models;

namespace MyHardware.Data
{
    public class ApplicationMySqlDbContext : DbContext, IApplicationDbContext
    {
        public IConfiguration _configuration { get; set; }

        public ApplicationMySqlDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"),
                      ServerVersion.AutoDetect(_configuration.GetConnectionString("DefaultConnection")));
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Adress> Adress { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierProduct> SupplierProduct { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SupplierProductCustomer> SupplierProductCustomer { get; set; }

        public int Save()
        {
            return SaveChanges();
        }
    }
}
