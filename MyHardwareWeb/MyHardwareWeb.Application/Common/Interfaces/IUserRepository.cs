using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface IUserRepository
    {
        Task Create(User adressModel);
        User Update(User adressModel);
        Task<User?> FindById(int id);
        Task<IEnumerable<User>> GetAll();
    }
}
