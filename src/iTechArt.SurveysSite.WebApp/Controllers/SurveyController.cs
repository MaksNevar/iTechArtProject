using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
        public IActionResult MySurveys()
        {
            return View();
        }

        public IActionResult NewSurvey()
        {
            return View();
        }
    }
}
