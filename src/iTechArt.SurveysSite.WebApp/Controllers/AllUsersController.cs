using System.Linq;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Foundation;
using iTechArt.SurveysSite.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    [Authorize(Roles = RoleNames.AdminRole)]
    public class AllUsersController : Controller
    {
        private readonly IUserManagementService _userManagementService;


        public AllUsersController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userManagementService.GetAllUsersAsync();
            var usersViewModel = users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Name = user.UserName,
                RoleNames = user.UserRoles.Select(ur => ur.Role.Name).ToList(),
                DateOfRegistration = user.RegistrationDate
            }).ToList();

            return View(usersViewModel);
        }
    }
}
