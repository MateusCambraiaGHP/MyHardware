using MyHardware.ViewModel;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ISupplierProductService
    {
        SupplierProductViewModel FindById(int id);

        SupplierProductViewModel GetAll();
    }
}
