using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
        [HttpGet]
        public IActionResult MySurveys()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewSurvey()
        {
            return View();
        }
    }
}
