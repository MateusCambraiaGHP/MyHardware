
using MyHardware.ViewModel;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ISupplierProductCustomerService
    {
        SupplierProductCustomerViewModel FindById(int id);

        SupplierProductCustomerViewModel GetAll();
    }
}
