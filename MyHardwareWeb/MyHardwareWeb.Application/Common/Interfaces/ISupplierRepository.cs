using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ISupplierRepository 
    {
        Task Create(Supplier adressModel);
        Supplier Update(Supplier adressModel);
        Task<Supplier?> FindById(int id);
        Task<IEnumerable<Supplier>> GetAll();
    }
}
