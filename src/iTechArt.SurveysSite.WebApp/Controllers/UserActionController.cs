using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Foundation;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public class UserActionController : Controller
    {
        private readonly IUserService _userService;


        public UserActionController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                ViewBag.Message = "Username cannot be empty";

                return View();
            }

            var newUser = new User() {FullName = username};
            _userService.CreateUser(newUser);

            ViewBag.Message = "User created";

            return View();
        }

        public async Task<IActionResult> DisplayAllUsersAsync()
        {
            return View("DisplayAllUsers", await _userService.GetAllUsersAsync());
        }
    }
}
