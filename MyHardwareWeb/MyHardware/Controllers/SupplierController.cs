using Microsoft.AspNetCore.Mvc;
using static MyHardware.Utility.Constants;
using MyHardware.ViewModel;
using AutoMapper;
using MyHardwareWeb.Application.Interfaces;

namespace MyHardware.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(SupplierViewModel supplierModel)
        {
            _supplierService.Save(supplierModel);
            TempData["success"] = "Fornecedor criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == DefaultValue.Inactive)
            {
                return NotFound();
            }
            var currentSupplier = _supplierService.FindById(id);
            if (currentSupplier == null)
            {
                return NotFound();
            }
            return View(currentSupplier);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SupplierViewModel supplierModel)
        {
            _supplierService.Edit(supplierModel);
            TempData["success"] = "Fornecedor alterado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult GetInviteDialog()
        {
            return PartialView("_InviteCustomerPartial");
        }
        //[HttpGet("export")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Export()
        //{
        //    _supplierRepository.ExportAllSupplier();
        //    return Ok();
        //}
    }
}