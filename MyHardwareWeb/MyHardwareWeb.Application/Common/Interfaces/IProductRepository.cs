using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface IProductRepository 
    {
        Task Create(Product adressModel);
        Product Update(Product adressModel);
        Task<Product?> FindById(int id);
        Task<IEnumerable<Product>> GetAll();
    }
}
