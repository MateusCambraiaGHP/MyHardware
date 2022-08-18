using MyHardware.ViewModel;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface IProductService
    {
        Task Save(ProductViewModel customerModel);

        void Edit(ProductViewModel customerModel);

        ProductViewModel FindById(int id);

        ProductViewModel GetAll();
    }
}
