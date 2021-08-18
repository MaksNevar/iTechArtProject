using System.Threading.Tasks;
using iTechArt.SurveysSite.Foundation;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;


        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }


        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userManagementService.DeleteUserAsync(id);

            return RedirectToAction("Index", "AllUsers");
        }
    }
}
