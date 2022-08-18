using MyHardware.ViewModel;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ISupplierProductService
    {
        Task<SupplierProductViewModel> FindById(int id);

        Task<SupplierProductViewModel>  GetAll();
    }
}
