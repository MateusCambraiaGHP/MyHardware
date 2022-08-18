using MyHardware.ViewModel;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ICustomerService
    {
        Task Save(CustomerViewModel customerModel);

        void Edit(CustomerViewModel customerModel);

        CustomerViewModel FindById(int id);

        CustomerViewModel GetAll();
    }
}
