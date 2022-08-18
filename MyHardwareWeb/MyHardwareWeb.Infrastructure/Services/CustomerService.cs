using AutoMapper;
using MyHardware.ViewModel;
using MyHardwareWeb.Application.Interfaces;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerViewModel> Save(CustomerViewModel customerModel)
        {
            var customerMap = _mapper.Map<CustomerViewModel, Customer>(customerModel);
            await _customerRepository.Create(customerMap);
            return customerModel;
        }

        public CustomerViewModel Edit(CustomerViewModel customerModel)
        {
            var customerMap = _mapper.Map<CustomerViewModel, Customer>(customerModel);
            _customerRepository.Update(customerMap);
            return customerModel;
        }

        public async Task<CustomerViewModel> FindByIdAsync(int id)
        {
            var currentCustomer = await _customerRepository.FindById(id) ?? new Customer();
            var customerMap = _mapper.Map<Customer, CustomerViewModel>(currentCustomer);
            return customerMap;
        }

        public async Task<CustomerViewModel> GetAll()
        {
            var listCustomer = await _customerRepository.GetAll() ?? new List<Customer>();
            var listCustomerMap = _mapper.Map<IEnumerable<Customer>, CustomerViewModel>(listCustomer);
            return listCustomerMap;
        }
    }
}