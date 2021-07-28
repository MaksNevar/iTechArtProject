using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Foundation;
using iTechArt.SurveysSite.WebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IUserService _userService;


        public UserManagementController(IUserService userService)
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

            var newUser = new User() { FullName = username };
            _userService.CreateUser(newUser);

            ViewBag.Message = "User created";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DisplayAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            var userViewModel = new UserViewModel() {Users = users};

            return View("DisplayAllUsers", userViewModel);
        }
    }
}