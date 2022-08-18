using AutoMapper;
using MyHardware.ViewModel;
using MyHardwareWeb.Application.Interfaces;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<ProductViewModel> Save(ProductViewModel productModel)
        {
            var productMap = _mapper.Map<ProductViewModel, Product>(productModel);
            await _productRepository.Create(productMap);
            return productModel;
        }

        public ProductViewModel Edit(ProductViewModel productModel)
        {
            var productMap = _mapper.Map<ProductViewModel, Product>(productModel);
            _productRepository.Update(productMap);
            return productModel;
        }

        public async Task<ProductViewModel> FindById(int id)
        {
            var currentProduct = await _productRepository.FindById(id) ?? new Product();
            var productMap = _mapper.Map<Product, ProductViewModel>(currentProduct);
            return productMap;
        }

        public async Task<ProductViewModel> GetAll()
        {
            var listProduct = await _productRepository.GetAll() ?? new List<Product>();
            var listProductMap = _mapper.Map<IEnumerable<Product>, ProductViewModel>(listProduct);
            return listProductMap;
        }
    }
}
