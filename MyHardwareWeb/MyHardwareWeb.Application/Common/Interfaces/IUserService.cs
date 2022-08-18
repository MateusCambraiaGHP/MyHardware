using MyHardware.ViewModel;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface IUserService
    {
        Task Save(UserViewModel customerModel);

        void Edit(UserViewModel customerModel);

        UserViewModel FindById(int id);

        UserViewModel GetAll();
    }
}
