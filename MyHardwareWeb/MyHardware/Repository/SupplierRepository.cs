using MyHardware.Interfaces;

namespace MyHardware.Repository
{
    public interface ISupplierRepository 
    { 
        
    }
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly IProductExcelService _excelService;

        public SupplierRepository(
            IApplicationDbContext db,
            IProductExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }

    }
}
