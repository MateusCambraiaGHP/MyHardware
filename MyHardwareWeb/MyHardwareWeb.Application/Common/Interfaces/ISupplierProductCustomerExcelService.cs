
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Application.Interfaces
{
    public interface ISupplierProductCustomerExcelService
    {
        Task ExportToExcel(IEnumerable<SupplierProductCustomer> entityList, string path, string name);
    }
}
