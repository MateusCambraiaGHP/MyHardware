using Microsoft.AspNetCore.Mvc;
using MyHardware.Repository;
using static MyHardware.Utility.Constants;
using MyHardware.ViewModel;
using AutoMapper;
using MyHardware.Models;

namespace MyHardware.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierRepository supplierRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public IActionResult Index()
        {
            var allProducts = _supplierRepository.GetAllSupplier();
            return View(allProducts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(ProductViewModel productModel)
        {
            if (ModelState.IsValid)
                _supplierRepository.Create(productModel);
                TempData["success"] = "Fornecedor criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == DefaultValue.Inactive)
            {
                return NotFound();
            }
            var currentProduct = _supplierRepository.FindSupplierById(id);
            if (currentProduct == null)
            {
                return NotFound();
            }
            return View("ProductViewModel", currentProduct);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel productModel)
        {
            if (ModelState.IsValid)
            {
                var productMap = _mapper.Map<ProductViewModel, Product>(productModel);
                _supplierRepository.Update(productMap);
            }
            TempData["success"] = "Fornecedor alterado com sucesso.";
            return RedirectToAction("Index");
        }

        [HttpGet("export")]
        [ValidateAntiForgeryToken]
        public IActionResult Export()
        {
            _supplierRepository.ExportAllSupplier();
            return Ok();
        }
    }
}