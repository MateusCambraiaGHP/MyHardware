using MyHardware.Interfaces;
using MyHardware.Models;

namespace MyHardware.Repository
{
    public interface ISupplierProductCustomerRepository
    {
        Task Create(SupplierProductCustomer supplierProductCustomerModel);
        SupplierProductCustomer Update(SupplierProductCustomer supplierProductCustomerModel);
        Task<SupplierProductCustomer?> FindsupplierProductCustomerById(int id);
        Task<IEnumerable<SupplierProductCustomer>> GetAllsupplierProductCustomer();
        Task ExportAllsupplierProductCustomer();
    }
    public class SupplierProductCustomerRepository : ISupplierProductCustomerRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly ISupplierProductCustomerExcelService _excelService;

        public SupplierProductCustomerRepository(
            IApplicationDbContext db,
            ISupplierProductCustomerExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }

        public async Task Create(SupplierProductCustomer supplierProductCustomerModel)
        {
            await _db.SupplierProductCustomer.AddAsync(supplierProductCustomerModel);
            _db.Save();
        }

        public SupplierProductCustomer Update(SupplierProductCustomer supplierProductCustomerModel)
        {
            _db.SupplierProductCustomer.Update(supplierProductCustomerModel);
            _db.Save();
            return supplierProductCustomerModel;
        }

        public async Task<SupplierProductCustomer?> FindAdressById(int id)
        {
            var currentSupplierProductCustomer = await _db.SupplierProductCustomer.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            return currentSupplierProductCustomer;
        }

        public async Task<IEnumerable<SupplierProductCustomer>> GetAllAdress()
        {
            IEnumerable<SupplierProductCustomer> currentSupplierProductCustomer = await _db.SupplierProductCustomer.ToListAsync();
            return currentSupplierProductCustomer;
        }

        public async Task ExportAllAdress()
        {
            IEnumerable<Adress> listSupplierProductCustomer = await _db.SupplierProductCustomer.ToListAsync();
            await _excelService.ExportToExcel(listSupplierProductCustomer, "C:/ProjetosMateusPadraoMvc/MathDrinksWeb/MathDrinks/excel", "supplierProductCustomer");
            return;
        }
    }
}
