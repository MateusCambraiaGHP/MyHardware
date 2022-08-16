using MyHardware.Models;

namespace MyHardware.Interfaces
{
    public interface ISupplierProductCustomerExcelService
    {
        Task ExportToExcel(IEnumerable<SupplierProductCustomer> entityList, string path, string name);
    }
}
