using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public class NewSurveyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
