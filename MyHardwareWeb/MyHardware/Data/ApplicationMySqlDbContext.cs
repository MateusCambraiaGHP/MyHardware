using Microsoft.EntityFrameworkCore;
using MyHardware.Interfaces;

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
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Supplier_Product> Supplier_Product { get; set; }

        public int Save()
        {
            return SaveChanges();
        }
    }
}
}
