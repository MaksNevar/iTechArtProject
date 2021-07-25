using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Foundation;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public sealed class HomeController : Controller
    {
        private readonly IUserService _userService;


        public HomeController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DisplayAllUsersAsync()
        {
            return View("DisplayAllUsers", await _userService.GetAllUsersAsync());
        }
    }
}