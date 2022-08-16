using MyHardware.Interfaces;
using MyHardware.Models;

namespace MyHardware.Repository
{
    public interface ISupplierRepository 
    {
        Task Create(Supplier supplierModel);
        Supplier Update(Supplier supplierModel);
        Task<Supplier?> FindSupplierById(int id);
        Task<IEnumerable<Supplier>> GetAllSupplier();
        Task ExportAllSupplier();
    }
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly ISupplierExcelService _excelService;

        public SupplierRepository(
            IApplicationDbContext db,
            ISupplierExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }

        public async Task Create(Supplier supplierModel)
        {
            await _db.Supplier.AddAsync(supplierModel);
            _db.Save();
        }

        public Supplier Update(Supplier supplierModel)
        {
            _db.Supplier.Update(supplierModel);
            _db.Save();
            return supplierModel;
        }

        public async Task<Supplier?> FindSupplierById(int id)
        {
            var currentSupplier = await _db.Supplier.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            return currentSupplier;
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplier()
        {
            IEnumerable<Supplier> currentSupplier = await _db.Supplier.ToListAsync();
            return currentSupplier;
        }

        public async Task ExportAllSupplier()
        {
            IEnumerable<Adress> listSupplier = await _db.Supplier.ToListAsync();
            await _excelService.ExportToExcel(listSupplier, "C:/ProjetosMateusPadraoMvc/MathDrinksWeb/MathDrinks/excel", "supplier");
            return;
        }
    }
}
