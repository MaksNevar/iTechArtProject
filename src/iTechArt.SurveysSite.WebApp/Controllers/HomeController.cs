using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public sealed class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewSurvey()
        {
            return View();
        }

        public IActionResult MySurveys()
        {
            return View();
        }

        public IActionResult SurveysTemplates()
        {
            return View();
        }
    }
}