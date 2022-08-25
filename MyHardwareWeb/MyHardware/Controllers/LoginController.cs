using Microsoft.AspNetCore.Mvc;
using static MyHardware.Utility.Constants;
using MyHardware.ViewModel;
using MyHardwareWeb.Application.Interfaces;

namespace MyHardware.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IUserService userService,
            ILogger<LoginController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> ValidatePassword(UserViewModel model)
        {
            await Validate(model);

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary
                    (
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );
                return BadRequest(new { errors });
            }

            TempData["success"] = "Login Efetuado com sucesso.";
            return RedirectToAction("Index", "Product");
        }
        
        public IActionResult GetRegisterDialog()
        {
            return PartialView("_RegisterUser"); 
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

        #region
        private async Task Validate(UserViewModel model)
        {
            if (String.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("Email", "Preencha o e-mail.");
            }

            if (ModelState.ErrorCount == 0 && String.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "Preencha a Senha.");
            }
            if (ModelState.ErrorCount == 0)
            {
                var isValid = await _userService.ValidatePassword(model);
                if (!isValid)
                ModelState.AddModelError("Password", "Email ou senha incorretos.");
            }

            return;
        }
        #endregion
    }
}