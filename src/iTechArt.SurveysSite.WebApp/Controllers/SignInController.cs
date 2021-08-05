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
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserByNameAsync(userView.UserName);

                if (user == null)
                {
                    ViewBag.Message = "The user does not exist";

                    return View();
                }

                user = await _userService.SignInAsync(userView.UserName, userView.Password);

                if (user != null)
                {
                    return Redirect("~/Home/Index");
                }

                ViewBag.Message = "Password is not correct";

                return View();
            }

            ViewBag.Message = "Please enter login and password";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userService.SignOutAsync();

            return Redirect("~/Home/Index");
        }
    }
}