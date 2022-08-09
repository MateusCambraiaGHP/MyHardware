using Microsoft.EntityFrameworkCore;
using MyHardware.Interfaces;
using MyHardware.Models;

namespace MyHardware.Repository
{
    public interface IProductRepository 
    {
        Task Create(Product productModel);
        Product Update(Product productModel);
        Task<Product?> FindProductById(int id);
        Task<IEnumerable<Product>>  GetAllProduct();
        Task ExportAllProducts();
    }
    public class ProductRepository : IProductRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly IProductExcelService _excelService;

        public ProductRepository(
            IApplicationDbContext db,
            IProductExcelService excelService)
        {
            _db = db;
            _excelService = excelService;
        }

        public async Task Create(Product productModel)
        {
            await _db.Product.AddAsync(productModel);
            _db.Save();
        }

        public Product Update(Product productModel)
        {
            _db.Product.Update(productModel);
            _db.Save();
            return productModel;
        }

        public async Task<Product?> FindProductById(int id) 
        {
            var currentProduct = await _db.Product.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            return currentProduct;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            IEnumerable<Product> currentProduct = await _db.Product.ToListAsync();
            return currentProduct;
        }

        public async Task ExportAllProducts()
        {
            IEnumerable<Product> currentProduct = await _db.Product.ToListAsync();
            await _excelService.ExportToExcel(currentProduct, "C:/ProjetosMateusPadraoMvc/MathDrinksWeb/MathDrinks/excel", "products");
            return;
        }
    }
}
