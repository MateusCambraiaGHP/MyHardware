using MyHardware.Models;

namespace MyHardware.Interfaces
{
    public interface ISupplierExcelService
    {
        Task ExportToExcel(IEnumerable<Supplier> entityList, string path, string name);
    }
}
