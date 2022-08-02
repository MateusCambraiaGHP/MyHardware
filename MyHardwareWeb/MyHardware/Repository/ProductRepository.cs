using Microsoft.EntityFrameworkCore;
using MyHardware.Interfaces;
using MyHardware.Models;

namespace MyHardware.Repository
{
    public interface IProductRepository 
    {
        public Task<Product> CreateProduct(Product productModel);
        public Task<IEnumerable<Product>>  GetAllProduct();
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

        public async Task<Product> CreateProduct(Product productModel)
        {
            await _db.Product.AddAsync(productModel);
            _db.Save();
            return productModel;
        }

        //public async Task GetProductId(int id)
        //{
        //    var productFromDb = await _db.Product.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
        //    return (new { productFromDb?.Price, productFromDb?.Description });
        //}

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            IEnumerable<Product> producsObj = await _db.Product.ToListAsync();
            return producsObj;
        }

        public async Task Export()
        {
            IEnumerable<Product> products = await _db.Product.ToListAsync();
            await _excelService.ExportToExcel(products, "C:/ProjetosMateusPadraoMvc/MathDrinksWeb/MathDrinks/excel", "products");
            return;
        }
    }
}
