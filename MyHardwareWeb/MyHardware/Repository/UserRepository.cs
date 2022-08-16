using MyHardware.Interfaces;
using MyHardware.Models;

namespace MyHardware.Repository
{
    public interface IUserRepository
    {
        Task Create(User userModel);
        User Update(User userModel);
        Task<User?> FindUserById(int id);
        Task<IEnumerable<User>> GetAllUser();
        Task ExportAllUser();
    }
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly IUserExcelService _excelService;

        public UserRepository(
            IApplicationDbContext db,
            IUserExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }

        public async Task Create(User userModel)
        {
            await _db.User.AddAsync(userModel);
            _db.Save();
        }

        public User Update(User userModel)
        {
            _db.User.Update(userModel);
            _db.Save();
            return userModel;
        }

        public async Task<User?> FindUserById(int id)
        {
            var currentUser = await _db.User.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            return currentUser;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            IEnumerable<User> currentUser = await _db.User.ToListAsync();
            return currentUser;
        }

        public async Task ExportAllUser()
        {
            IEnumerable<User> listUser = await _db.User.ToListAsync();
            await _excelService.ExportToExcel(listUser, "C:/ProjetosMateusPadraoMvc/MathDrinksWeb/MathDrinks/excel", "user");
            return;
        }
    }
}
