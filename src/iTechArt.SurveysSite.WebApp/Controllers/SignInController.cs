using System.Threading.Tasks;
using iTechArt.SurveysSite.Foundation;
using iTechArt.SurveysSite.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public class SignInController : Controller
    {
        private readonly IUserService _userService;


        public SignInController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModel userView)
        {
            if (!ModelState.IsValid)
            {
                return View(userView);
            }

            var user = await _userService.GetUserByUsernameAsync(userView.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", $"User \"{userView.UserName}\" does not exist");

                return View(userView);
            }

            var result = await _userService.SignInAsync(userView.UserName, userView.Password);

            if (result)
            {
                return Redirect("~/Home/Index");
            }

            ModelState.AddModelError("", "Password is not correct");

            return View(userView);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userService.SignOutAsync();

            return Redirect("~/Home/Index");
        }
    }
}