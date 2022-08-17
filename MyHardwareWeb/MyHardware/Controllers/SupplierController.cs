using Microsoft.AspNetCore.Mvc;
using static MyHardware.Utility.Constants;
using MyHardware.ViewModel;
using AutoMapper;

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
            var allSuppliers = _supplierRepository.GetAllSupplier();
            return View(allSuppliers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(SupplierViewModel supplierModel)
        {
            if (ModelState.IsValid)
            {
                var supplierMap = _mapper.Map<SupplierViewModel, Supplier>(supplierModel);
                _supplierRepository.Create(supplierMap);
            }
            TempData["success"] = "Fornecedor criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == DefaultValue.Inactive)
            {
                return NotFound();
            }
            var currentSupplier = _supplierRepository.FindSupplierById(id);
            if (currentSupplier == null)
            {
                return NotFound();
            }
            return View("SupplierViewModel", currentSupplier);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SupplierViewModel supplierModel)
        {
            if (ModelState.IsValid)
            {
                var supplierMap = _mapper.Map<SupplierViewModel, Supplier>(supplierModel);
                _supplierRepository.Update(supplierMap);
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