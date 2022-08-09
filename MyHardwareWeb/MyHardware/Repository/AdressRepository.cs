using Microsoft.EntityFrameworkCore;
using MyHardware.Interfaces;
using MyHardware.Models;

namespace MyHardware.Repository
{
    public interface IAdressRepository
    {
        Task Create(Adress adressModel);
        Adress Update(Adress adressModel);
        Task<Adress?> FindAdressById(int id);
        Task<IEnumerable<Adress>> GetAllAdress();
        Task ExportAllAdress();
    }
    public class AdressRepository : IAdressRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly IAdressExcelService _excelService;

        public AdressRepository(
            IApplicationDbContext db,
            IAdressExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }

        public async Task Create(Adress adressModel)
        {
            await _db.Adress.AddAsync(adressModel);
            _db.Save();
        }

        public Adress Update(Adress adressModel)
        {
            _db.Adress.Update(adressModel);
            _db.Save();
            return adressModel;
        }

        public async Task<Adress?> FindAdressById(int id)
        {
            var currentAdress = await _db.Adress.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            return currentAdress;
        }

        public async Task<IEnumerable<Adress>> GetAllAdress()
        {
            IEnumerable<Adress> currentAdress = await _db.Adress.ToListAsync();
            return currentAdress;
        }

        public async Task ExportAllAdress()
        {
            IEnumerable<Adress> listAdress = await _db.Adress.ToListAsync();
            await _excelService.ExportToExcel(listAdress, "C:/ProjetosMateusPadraoMvc/MathDrinksWeb/MathDrinks/excel", "adress");
            return;
        }
    }
}
