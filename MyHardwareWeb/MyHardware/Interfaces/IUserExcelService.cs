using MyHardware.Models;

namespace MyHardware.Interfaces
{
    public interface IUserExcelService
    {
        Task ExportToExcel(IEnumerable<User> entityList, string path, string name);
    }
}
