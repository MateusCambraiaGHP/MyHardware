using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ICustomerRepository 
    {
        Task Create(Customer adressModel);
        Customer Update(Customer adressModel);
        Task<Customer?> FindById(int id);
        Task<IEnumerable<Customer>> GetAll();
    }
}
