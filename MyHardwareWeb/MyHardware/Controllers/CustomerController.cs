using Microsoft.AspNetCore.Mvc;
using MyHardware.ViewModel;
using MyHardwareWeb.Application.Interfaces;

namespace MyHardware.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(
            ICustomerService customerService)
        {
            _customerService = customerService;
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
        public IActionResult Save(CustomerViewModel customerModel)
        {
            _customerService.Save(customerModel);
            TempData["success"] = "Cliente criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var currentCustomer = _customerService.FindByIdAsync(id);
            if (currentCustomer is null)
                return NotFound();
            return View(currentCustomer);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerViewModel customerModel)
        {
            _customerService.Edit(customerModel);
            TempData["success"] = "Cliente alterado com sucesso.";
            return RedirectToAction("Index");
        }

        //[HttpGet("export")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Export()
        //{
        //    _customerService.ExportAllCustomer();
        //    return Ok();
        //}
    }
}