using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Foundation;
using Microsoft.AspNetCore.Mvc;
using iTechArt.SurveysSite.WebApp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;


        public RegisterController(IUserService userService)
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

            var result = await _userService.CreateUserAsync(registerModel.Login, registerModel.Email, registerModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "SignIn");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(registerModel);
        }
    }
}
