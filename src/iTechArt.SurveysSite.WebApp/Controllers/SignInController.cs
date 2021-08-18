using System.Threading.Tasks;
using iTechArt.SurveysSite.Foundation;
using iTechArt.SurveysSite.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public class SignInController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserManagementService _userManagementService;


        public SignInController(IAccountService accountService, IUserManagementService userManagementService)
        {
            _accountService = accountService;
            _userManagementService = userManagementService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userView)
        {
            if (!ModelState.IsValid)
            {
                return View(userView);
            }

            var user = await _userManagementService.GetUserByUsernameAsync(userView.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", $"User \"{userView.UserName}\" does not exist");

                return View(userView);
            }

            var result = await _accountService.SignInAsync(userView.UserName, userView.Password);

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
            await _accountService.SignOutAsync();

            return Redirect("~/Home/Index");
        }
    }
}