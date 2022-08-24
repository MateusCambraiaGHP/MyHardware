using AutoMapper;
using MyHardware.ViewModel;
using MyHardwareWeb.Application.Interfaces;
using MyHardwareWeb.Domain.Models;

namespace MyHardwareWeb.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<bool> ValidatePassword(UserViewModel userModel)
        {
            var userMap = _mapper.Map<UserViewModel, User>(userModel);
            return await _userRepository.GetByEmailAndPassword(userMap);
        }
        public async Task<UserViewModel> Save(UserViewModel customerModel)
        {
            var customerMap = _mapper.Map<UserViewModel, User>(customerModel);
            await _userRepository.Create(customerMap);
            return customerModel;
        }

        public UserViewModel Edit(UserViewModel customerModel)
        {
            var customerMap = _mapper.Map<UserViewModel, User>(customerModel);
            _userRepository.Update(customerMap);
            return customerModel;
        }

        public async Task<UserViewModel> FindById(int id)
        {
            var currentCustomer = await _userRepository.FindById(id) ?? new User();
            var customerMap = _mapper.Map<User, UserViewModel>(currentCustomer);
            return customerMap;
        }

        public async Task<UserViewModel> GetAll()
        {
            var listCustomer = await _userRepository.GetAll() ?? new List<User>();
            var listCustomerMap = _mapper.Map<IEnumerable<User>, UserViewModel>(listCustomer);
            return listCustomerMap;
        }
    }
}
