using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ISupplierExcelService
    {
        Task ExportToExcel(IEnumerable<Supplier> entityList, string path, string name);
    }
}
