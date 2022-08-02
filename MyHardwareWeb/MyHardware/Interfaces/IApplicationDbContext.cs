using Microsoft.EntityFrameworkCore;
using MyHardware.Models;

namespace MyHardware.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Adress>? Adress { get; set; }
        public DbSet<Customer>? Customer { get; set; }
        public DbSet<SupplierProduct>? SupplierProduct { get; set; }
        public DbSet<User>? User { get; set; }
        public DbSet<SupplierProductCustomer>? SupplierProductCustomer { get; set; }
        public int Save();
    }
}
