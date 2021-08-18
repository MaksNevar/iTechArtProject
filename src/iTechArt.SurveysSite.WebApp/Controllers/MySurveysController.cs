using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    [Authorize]
    public class MySurveysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
