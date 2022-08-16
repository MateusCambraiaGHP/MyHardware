using MyHardware.Models;

namespace MyHardware.Interfaces
{
    public interface IAdressExcelService
    {
        Task ExportToExcel(IEnumerable<Adress> entityList, string path, string name);
    }
}
