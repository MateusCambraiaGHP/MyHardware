using MyHardwareWeb.Application.Interfaces;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Infrastructure.Services
{
    public class UserService : ExcelService<User>, IUserExcelService { }
}
