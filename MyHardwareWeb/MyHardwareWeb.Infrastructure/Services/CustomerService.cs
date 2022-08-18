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

        public async Task Save(CustomerViewModel customerModel)
        {
            var customerMap = _mapper.Map<CustomerViewModel, Customer>(customerModel);
            await _customerRepository.Create(customerMap);
        }

        public void Edit(CustomerViewModel customerModel)
        {
            var customerMap = _mapper.Map<CustomerViewModel, Customer>(customerModel);
            _customerRepository.Update(customerMap);
        }

        public CustomerViewModel FindById(int id)
        {
            var currentEntity = _customerRepository.FindById(id).Result;
            var customerMap = _mapper.Map<Customer, CustomerViewModel>(currentEntity);
            return customerMap;
        }

        public CustomerViewModel GetAll()
        {
            var listCustomer = _customerRepository.GetAll().Result;
            var listCustomerMap = _mapper.Map<IEnumerable<Customer>, CustomerViewModel>(listCustomer);
            return listCustomerMap;
        }
    }
}