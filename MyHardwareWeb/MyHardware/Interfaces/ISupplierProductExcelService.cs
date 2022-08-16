using MyHardware.Models;

namespace MyHardware.Interfaces
{
    public interface ISupplierProductExcelService
    {
        Task ExportToExcel(IEnumerable<SupplierProduct> entityList, string path, string name);
    }
}
