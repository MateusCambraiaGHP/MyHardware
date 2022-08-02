using MyHardware.Interfaces;

namespace MyHardware.Repository
{
    public interface IAdressRepository 
    { 
        
    }
    public class AdressRepository : IAdressRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly IProducExcelService _excelService;

        public AdressRepository(
            IApplicationDbContext db,
            IProducExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }


    }
}
