
using MyHardware.ViewModel;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ISupplierProductCustomerService
    {
        Task<SupplierProductCustomerViewModel> FindById(int id);

        Task<SupplierProductCustomerViewModel> GetAll();
    }
}
