using MyHardware.ViewModel;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ISupplierService
    {
        Task Save(SupplierViewModel customerModel);

        void Edit(SupplierViewModel customerModel);

        SupplierViewModel FindById(int id);

        SupplierViewModel GetAll();
    }
}
