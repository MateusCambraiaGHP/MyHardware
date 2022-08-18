using MyHardware.ViewModel;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerViewModel> Save(CustomerViewModel customerModel);

        CustomerViewModel Edit(CustomerViewModel customerModel);

        Task<CustomerViewModel> FindByIdAsync(int id);

        Task<CustomerViewModel> GetAll();
    }
}
