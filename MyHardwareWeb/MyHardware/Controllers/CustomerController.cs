using Microsoft.AspNetCore.Mvc;
using static MyHardware.Utility.Constants;
using MyHardware.ViewModel;
using AutoMapper;
using MyHardware.Application.Interfaces;
using MyHardwareWeb.Domain.Models;

namespace MyHardware.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService,
            IMapper mapper)
        {
            _mapper = mapper;
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
            if (ModelState.IsValid)
            {
                var customerMap = _mapper.Map<CustomerViewModel, Customer>(customerModel);
                _customerService.Create(customerMap);
            }
            TempData["success"] = "Cliente criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var currentCustomer = _customerService.FindCustomerById(id);
            if (currentCustomer == null)
                return NotFound();
            return View(currentCustomer);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerViewModel customerModel)
        {
            if (ModelState.IsValid)
            {
                var customerMap = _mapper.Map<CustomerViewModel, Customer>(customerModel);
                _customerService.Update(customerMap);
            }
            TempData["success"] = "Cliente alterado com sucesso.";
            return RedirectToAction("Index");
        }

        [HttpGet("export")]
        [ValidateAntiForgeryToken]
        public IActionResult Export()
        {
            _customerService.ExportAllCustomer();
            return Ok();
        }
    }
}