using MyHardware.Interfaces;

namespace MyHardware.Repository
{
    public interface ISupplierProductRepository
    { 
        
    }
    public class SupplierProductRepository : ISupplierProductRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly IProductExcelService _excelService;

        public SupplierProductRepository(
            IApplicationDbContext db,
            IProductExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }
    }
}
