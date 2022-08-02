using MyHardware.Interfaces;

namespace MyHardware.Repository
{
    public interface ISupplierRepository 
    { 
        
    }
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly IProducExcelService _excelService;

        public SupplierRepository(
            IApplicationDbContext db,
            IProducExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }

    }
}
