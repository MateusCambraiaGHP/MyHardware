using MyHardwareWeb.Domain.Models;
namespace MyHardwareWeb.Application.Interfaces
{
    public interface IAdressRepository
    {
        Task Create(Adress adressModel);
        Adress Update(Adress adressModel);
        Task<Adress?> FindById(int id);
        Task<IEnumerable<Adress>> GetAll();
    }
}
