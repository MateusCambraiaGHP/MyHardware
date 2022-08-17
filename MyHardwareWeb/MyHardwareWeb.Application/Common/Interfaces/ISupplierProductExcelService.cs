using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ISupplierProductExcelService
    {
        Task ExportToExcel(IEnumerable<SupplierProduct> entityList, string path, string name);
    }
}
