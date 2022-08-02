using MyHardware.Interfaces;

namespace MyHardware.Repository
{
    public interface IUserRepository
    { 
        
    }
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly IProducExcelService _excelService;

        public UserRepository(
            IApplicationDbContext db,
            IProducExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }

    }
}
