using MyHardware.Interfaces;
using MyHardware.Models;

namespace MyHardware.Repository
{
    public interface ISupplierProductRepository
    {
        Task Create(SupplierProduct supplierProductModel);
        SupplierProduct Update(SupplierProduct supplierProductModel);
        Task<SupplierProduct?> FindSupplierProductById(int id);
        Task<IEnumerable<SupplierProduct>> GetAllSupplierProduct();
        Task ExportAllSupplierProduct();
    }
    public class SupplierProductRepository : ISupplierProductRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly ISupplierProductExcelService _excelService;

        public SupplierProductRepository(
            IApplicationDbContext db,
            ISupplierProductExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }

        public async Task Create(SupplierProduct supplierProductModel)
        {
            await _db.SupplierProduct.AddAsync(supplierProductModel);
            _db.Save();
        }

        public SupplierProduct Update(SupplierProduct supplierProductModel)
        {
            _db.SupplierProduct.Update(supplierProductModel);
            _db.Save();
            return supplierProductModel;
        }

        public async Task<SupplierProduct?> FindSupplierProductById(int id)
        {
            var currentSupplierProduct = await _db.SupplierProduct.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            return currentSupplierProduct;
        }

        public async Task<IEnumerable<SupplierProduct>> GetAllSupplierProduct()
        {
            IEnumerable<SupplierProduct> currentSupplierProduct = await _db.SupplierProduct.ToListAsync();
            return currentSupplierProduct;
        }

        public async Task ExportAllSupplierProduct()
        {
            IEnumerable<SupplierProduct> listSupplierProduct = await _db.SupplierProduct.ToListAsync();
            await _excelService.ExportToExcel(listSupplierProduct, "C:/ProjetosMateusPadraoMvc/MathDrinksWeb/MathDrinks/excel", "supplierProduct");
            return;
        }
    }
}
