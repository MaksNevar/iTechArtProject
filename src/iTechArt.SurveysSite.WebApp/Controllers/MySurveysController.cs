using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public class MySurveysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
