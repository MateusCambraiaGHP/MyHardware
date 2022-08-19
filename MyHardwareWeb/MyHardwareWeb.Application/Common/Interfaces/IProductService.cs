using MyHardware.ViewModel;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductViewModel> Save(ProductViewModel customerModel);

        ProductViewModel Edit(ProductViewModel customerModel);

        Task<ProductViewModel> FindById(int id);

        Task<ProductViewModel> GetAll();
    }
}
