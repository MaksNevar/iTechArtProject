using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Foundation;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public class CreateController : Controller
    {
        private readonly IUserService _userService;


        public CreateController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                ViewBag.Message = "Username cannot be empty";

                return View("Index");
            }

            var newUser = new User() {FullName = username};
            _userService.CreateUser(newUser);

            ViewBag.Message = "User created";

            return View("Index");
        }
    }
}
