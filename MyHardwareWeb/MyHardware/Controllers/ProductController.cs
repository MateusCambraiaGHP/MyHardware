﻿using Microsoft.AspNetCore.Mvc;
using MyHardware.Repository;
using static MyHardware.Utility.Constants;
using MyHardware.ViewModel;
using AutoMapper;
using MyHardware.Models;

namespace MyHardware.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var allProducts = _productRepository.GetAllProduct();
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
            {
                var productMap = _mapper.Map<ProductViewModel, Product>(productModel);
                _productRepository.Create(productMap);
            }

            TempData["success"] = "Produto criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == DefaultValue.Inactive)
            {
                return NotFound();
            }
            var currentProduct = _productRepository.FindProductById(id);
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
                _productRepository.Update(productMap);
            }
            TempData["success"] = "Produto alterado com sucesso.";
            return RedirectToAction("Index");
        }

        [HttpGet("export")]
        [ValidateAntiForgeryToken]
        public IActionResult Export()
        {
            _productRepository.ExportAllProducts();
            return Ok();
        }
    }
}