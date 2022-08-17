using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface IUserExcelService
    {
        Task ExportToExcel(IEnumerable<User> entityList, string path, string name);
    }
}
