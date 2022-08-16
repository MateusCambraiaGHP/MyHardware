using MyHardware.Models;

namespace MyHardware.Interfaces
{
    public interface ICustomerExcelService
    {
        Task ExportToExcel(IEnumerable<Customer> entityList, string path, string name);
    }
}
