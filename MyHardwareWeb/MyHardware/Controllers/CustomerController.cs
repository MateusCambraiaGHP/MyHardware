using Microsoft.AspNetCore.Mvc;
using MyHardware.Repository;
using static MyHardware.Utility.Constants;
using MyHardware.ViewModel;
using AutoMapper;
using MyHardware.Models;

namespace MyHardware.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var allProducts = _customerRepository.GetAllCustomer();
            return View(allProducts);
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
                _customerRepository.Create(customerMap);
            }
            TempData["success"] = "Cliente criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == DefaultValue.Inactive)
            {
                return NotFound();
            }
            var currentCustomer = _customerRepository.FindCustomerById(id);
            if (currentCustomer == null)
            {
                return NotFound();
            }
            return View("CustomerViewModel", currentCustomer);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerViewModel customerModel)
        {
            if (ModelState.IsValid)
            {
                var customerMap = _mapper.Map<CustomerViewModel, Customer>(customerModel);
                _customerRepository.Update(customerMap);
            }
            TempData["success"] = "Cliente alterado com sucesso.";
            return RedirectToAction("Index");
        }

        [HttpGet("export")]
        [ValidateAntiForgeryToken]
        public IActionResult Export()
        {
            _customerRepository.ExportAllCustomer();
            return Ok();
        }
    }
}