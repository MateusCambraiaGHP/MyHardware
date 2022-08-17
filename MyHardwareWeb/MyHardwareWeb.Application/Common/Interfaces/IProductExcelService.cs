using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface IProductExcelService
    {
        Task ExportToExcel(IEnumerable<Product> entityList, string path, string name);
    }
}
