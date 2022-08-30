using MyHardware.ViewModel;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> Save(UserViewModel userModel); 

        UserViewModel Edit(UserViewModel userModel);

        Task<UserViewModel> FindById(int id);

        Task<UserViewModel> GetAll();
        Task<bool> ValidatePassword(string email, string password);
    }
}
