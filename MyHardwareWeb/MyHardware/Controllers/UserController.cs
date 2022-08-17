using Microsoft.AspNetCore.Mvc;
using MyHardware.Repository;
using static MyHardware.Utility.Constants;
using MyHardware.ViewModel;
using AutoMapper;
using MyHardware.Models;

namespace MyHardware.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var allUsers = _userRepository.GetAllUser();
            return View(allUsers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var userMap = _mapper.Map<UserViewModel, User>(userModel);
                _userRepository.Create(userMap);            
            }
                TempData["success"] = "Usuário criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == DefaultValue.Inactive)
            {
                return NotFound();
            }
            var currentUser = _userRepository.FindUserById(id);
            if (currentUser == null)
            {
                return NotFound();
            }
            return View("UserViewModel", currentUser);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var userMap = _mapper.Map<UserViewModel, User>(userModel);
                _userRepository.Update(userMap);
            }
            TempData["success"] = "Usuário alterado com sucesso.";
            return RedirectToAction("Index");
        }

        [HttpGet("export")]
        [ValidateAntiForgeryToken]
        public IActionResult Export()
        {
            _userRepository.ExportAllUsers();
            return Ok();
        }
    }
}