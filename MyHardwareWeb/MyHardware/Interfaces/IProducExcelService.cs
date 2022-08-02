using MyHardware.Models;

namespace MyHardware.Interfaces
{
    public interface IProducExcelService
    {
        Task ExportToExcel(IEnumerable<Product> entityList, string path, string name);
    }
}
