using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Foundation;
using Microsoft.AspNetCore.Mvc;
using iTechArt.SurveysSite.WebApp.ViewModels;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAccountService _userService;


        public RegisterController(IAccountService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            var userToRegister = new User
            {
                UserName = registerModel.Login,
                Email = registerModel.Email
            };

            var result = await _userService.RegisterAsync(userToRegister, registerModel.Password);

            if (result.Succeeded)
            {
                ViewBag.Message = "Registration is successful";

                return View();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(registerModel);
        }
    }
}
