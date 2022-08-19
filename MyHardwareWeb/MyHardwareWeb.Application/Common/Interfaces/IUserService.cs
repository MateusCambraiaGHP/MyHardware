using MyHardware.ViewModel;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> Save(UserViewModel customerModel);

        UserViewModel Edit(UserViewModel customerModel);

        Task<UserViewModel> FindById(int id);

        Task<UserViewModel> GetAll();
    }
}
