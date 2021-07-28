using System.Linq;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Foundation;
using iTechArt.SurveysSite.WebApp.ViewModels;
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
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(UserViewModel userToCreate)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Username cannot be empty";

                return View();
            }

            var newUser = new User()
            {
                FullName = userToCreate.FullName
            };

            _userService.CreateUser(newUser);

            ViewBag.Message = "User created";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DisplayAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            var usersList = users.Select(user => new UserViewModel
            {
                Id = user.Id, 
                FullName = user.FullName
            }).ToList();

            var usersViewModel = new UsersViewModel
            {
                Users = usersList
            };

            return View("DisplayAllUsers", usersViewModel);
        }
    }
}