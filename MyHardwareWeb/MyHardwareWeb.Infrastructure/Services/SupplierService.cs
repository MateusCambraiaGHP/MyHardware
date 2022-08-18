using AutoMapper;
using MyHardware.ViewModel;
using MyHardwareWeb.Application.Interfaces;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Infrastructure.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<SupplierViewModel> Save(SupplierViewModel customerModel)
        {
            var customerMap = _mapper.Map<SupplierViewModel, Supplier>(customerModel);
            await _supplierRepository.Create(customerMap);
            return customerModel;
        }

        public SupplierViewModel Edit(SupplierViewModel customerModel)
        {
            var customerMap = _mapper.Map<SupplierViewModel, Supplier>(customerModel);
            _supplierRepository.Update(customerMap);
            return customerModel;
        }

        public async Task<SupplierViewModel> FindById(int id)
        {
            var currentCustomer = await _supplierRepository.FindById(id) ?? new Supplier();
            var customerMap = _mapper.Map<Supplier, SupplierViewModel>(currentCustomer);
            return customerMap;
        }

        public async Task<SupplierViewModel> GetAll()
        {
            var listCustomer = await _supplierRepository.GetAll() ?? new List<Supplier>(); ;
            var listCustomerMap = _mapper.Map<IEnumerable<Supplier>, SupplierViewModel>(listCustomer);
            return listCustomerMap;
        }
    }
}
