using MyHardware.Interfaces;
using MyHardware.Models;

namespace MyHardware.Services
{
    public class CustomerExcelService : ExcelService<Customer>, ICustomerExcelService {}
}
