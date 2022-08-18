using Microsoft.AspNetCore.Mvc;
using static MyHardware.Utility.Constants;
using MyHardware.ViewModel;
using AutoMapper;
using MyHardwareWeb.Application.Interfaces;

namespace MyHardware.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var allUsers = _userService.GetAll();
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
            _userService.Save(userModel);            
            TempData["success"] = "Usuário criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == DefaultValue.Inactive)
            {
                return NotFound();
            }
            var currentUser = _userService.FindById(id);
            if (currentUser == null)
            {
                return NotFound();
            }
            return View(currentUser);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserViewModel userModel)
        {
            _userService.Edit(userModel);
            TempData["success"] = "Usuário alterado com sucesso.";
            return RedirectToAction("Index");
        }

        //[HttpGet("export")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Export()
        //{
        //    _userRepository.ExportAllUsers();
        //    return Ok();
        //}
    }
}