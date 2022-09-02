using MyHardware.ViewModel;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailViewModel model);
    }
}
