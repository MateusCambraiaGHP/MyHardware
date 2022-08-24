using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface IUserRepository
    {
        Task Create(User adressModel);
        Task<bool> GetByEmailAndPassword(User userModel);
        User Update(User adressModel);
        Task<User?> FindById(int id);
        Task<IEnumerable<User>> GetAll();
    }
}
