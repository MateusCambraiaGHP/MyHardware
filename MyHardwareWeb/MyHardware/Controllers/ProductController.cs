using MyHardware.Interfaces;
using MyHardware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using OfficeOpenXml;
using MyHardware.Repository;
using MyHardware.ViewModel;

namespace MyHardware.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProducExcelService _excelService;
        private readonly IProductRepository _productRepository;

        public ProductController(
            IProducExcelService excelService,
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            var producsObj = _productRepository.GetAllProduct();
            return View(producsObj);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product productModel)
        {
            if (ModelState.IsValid)
                _productRepository.CreateProduct(productModel);
            TempData["success"] = "Produto criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Product.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
                _db.Product.Update(obj);
            _db.Save();
            TempData["success"] = "Produto editado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Product.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Product.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
            if (obj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
                _db.Product.Remove(obj);
            _db.Save();
            TempData["success"] = "Produto deletado com sucesso.";
            return RedirectToAction("Index");
        }
    }
}