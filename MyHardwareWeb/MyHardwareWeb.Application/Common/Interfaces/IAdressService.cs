using MyHardware.ViewModel;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface IAdressService
    {
        Task Save(AdressViewModel customerModel);

        void Edit(AdressViewModel customerModel);

        AdressViewModel FindById(int id);

        AdressViewModel GetAll();
    }
}
