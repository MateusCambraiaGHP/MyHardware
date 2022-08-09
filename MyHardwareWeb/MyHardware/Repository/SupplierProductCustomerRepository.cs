using MyHardware.Interfaces;

namespace MyHardware.Repository
{
    public interface ISupplierProductCustomerRepository
    { 
        
    }
    public class SupplierProductCustomerRepository : ISupplierProductCustomerRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly IProductExcelService _excelService;

        public SupplierProductCustomerRepository(
            IApplicationDbContext db,
            IProductExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }
    }
}
