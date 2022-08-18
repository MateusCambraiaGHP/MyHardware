using MyHardware.ViewModel;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<SupplierViewModel> Save(SupplierViewModel customerModel);

        SupplierViewModel Edit(SupplierViewModel customerModel);

        Task<SupplierViewModel> FindById(int id);

        Task<SupplierViewModel> GetAll();
    }
}
