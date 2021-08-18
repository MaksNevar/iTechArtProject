using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public class SurveysTemplatesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
