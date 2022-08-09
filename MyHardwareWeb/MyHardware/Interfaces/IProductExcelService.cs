using MyHardware.Models;

namespace MyHardware.Interfaces
{
    public interface IProductExcelService
    {
        Task ExportToExcel(IEnumerable<Product> entityList, string path, string name);
    }
    public interface IAdressExcelService
    {
        Task ExportToExcel(IEnumerable<Adress> entityList, string path, string name);
    }
    public interface ICustomerExcelService
    {
        Task ExportToExcel(IEnumerable<Customer> entityList, string path, string name);
    }
}
