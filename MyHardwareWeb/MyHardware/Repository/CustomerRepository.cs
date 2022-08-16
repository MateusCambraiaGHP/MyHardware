using Microsoft.EntityFrameworkCore;
using MyHardware.Interfaces;
using MyHardware.Models;

namespace MyHardware.Repository
{
    public interface ICustomerRepository 
    {
        Task Create(Customer customerModel);
        Customer Update(Customer customerModel);
        Task<Customer?> FindCustomerById(int id);
        Task<IEnumerable<Customer>>  GetAllCustomer();
        Task ExportAllCustomer();
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly ICustomerExcelService _excelService;

        public CustomerRepository(
            IApplicationDbContext db,
            ICustomerExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }

        public async Task Create(Customer customerModel)
        {
            await _db.Customer.AddAsync(customerModel);
            _db.Save();
        }

        public Customer Update(Customer customerModel)
        {
            _db.Customer.Update(customerModel);
            _db.Save();
            return customerModel;
        }

        public async Task<Customer?> FindCustomerById(int id) 
        {
            var currentCustomer = await _db.Customer.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            return currentCustomer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            IEnumerable<Customer> currentCustomer = await _db.Customer.ToListAsync();
            return currentCustomer;
        }

        public async Task ExportAllCustomer()
        {
            IEnumerable<Customer> listCustomer = await _db.Customer.ToListAsync();
            await _excelService.ExportToExcel(listCustomer, "C:/ProjetosMateusPadraoMvc/MathDrinksWeb/MathDrinks/excel", "customer");
            return;
        }
    }
}
