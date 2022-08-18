using Microsoft.AspNetCore.Mvc;
using static MyHardware.Utility.Constants;
using MyHardware.ViewModel;
using AutoMapper;
using MyHardwareWeb.Application.Interfaces;

namespace MyHardware.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost("save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(ProductViewModel productModel)
        {
            _productService.Save(productModel);
            TempData["success"] = "Produto criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == DefaultValue.Inactive)
            {
                return NotFound();
            }
            var currentProduct = _productService.FindById(id);
            if (currentProduct == null)
            {
                return NotFound();
            }
            return View(currentProduct);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel productModel)
        {
            _productService.Edit(productModel);
            TempData["success"] = "Produto alterado com sucesso.";
            return RedirectToAction("Index");
        }

        //[HttpGet("export")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Export()
        //{
        //    _productRepository.ExportAllProducts();
        //    return Ok();
        //}
    }
}