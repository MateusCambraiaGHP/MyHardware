using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface IAdressExcelService
    {
        Task ExportToExcel(IEnumerable<Adress> entityList, string path, string name);
    }
}
