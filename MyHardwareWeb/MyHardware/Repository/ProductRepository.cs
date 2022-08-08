using Microsoft.EntityFrameworkCore;
using MyHardware.Interfaces;
using MyHardware.Models;

namespace MyHardware.Repository
{
    public interface IProductRepository 
    {
        public Task InsertProductFromDatabase(Product productModel);
        public Product UpdateProductFromDatabase(Product productModel);
        public Task<Product?> FindProductById(int id);
        public Task<IEnumerable<Product>>  GetAllProduct();
        public Task ExportAllProducts();
    }
    public class ProductRepository : IProductRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly IProducExcelService _excelService;

        public ProductRepository(
            IApplicationDbContext db,
            IProducExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }

        public async Task InsertProductFromDatabase(Product productModel)
        {
            await _db.Product.AddAsync(productModel);
            _db.Save();
        }

        public Product UpdateProductFromDatabase(Product productModel)
        {
            _db.Product.Update(productModel);
            _db.Save();
            return productModel;
        }

        public async Task<Product?> FindProductById(int id) 
        {
            var productFromDb = await _db.Product.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            return productFromDb;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            IEnumerable<Product> producsObj = await _db.Product.ToListAsync();
            return producsObj;
        }

        public async Task ExportAllProducts()
        {
            IEnumerable<Product> products = await _db.Product.ToListAsync();
            await _excelService.ExportToExcel(products, "C:/ProjetosMateusPadraoMvc/MathDrinksWeb/MathDrinks/excel", "products");
            return;
        }
    }
}
