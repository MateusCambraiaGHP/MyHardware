using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ISupplierProductCustomerRepository
    {
        Task Create(SupplierProductCustomer adressModel);
        SupplierProductCustomer Update(SupplierProductCustomer adressModel);
        Task<SupplierProductCustomer?> FindById(int id);
        Task<IEnumerable<SupplierProductCustomer>> GetAll();
    }
}
