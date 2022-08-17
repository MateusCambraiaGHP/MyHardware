using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ISupplierProductRepository
    {
        Task Create(SupplierProduct adressModel);
        SupplierProduct Update(SupplierProduct adressModel);
        Task<SupplierProduct?> FindById(int id);
        Task<IEnumerable<SupplierProduct>> GetAll();
    }
}
