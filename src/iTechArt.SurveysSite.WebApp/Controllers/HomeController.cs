using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.SurveysSite.Foundation;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public sealed class HomeController : Controller
    {
        private readonly ILog _logger;
        private readonly IButtonClicksService _buttonClicks;


        public HomeController(ILog logger, IButtonClicksService buttonClicks)
        {
            _logger = logger;

            _buttonClicks = buttonClicks;
        }


        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Displaying current clicks number");

            return View(await _buttonClicks.GetCurrentButtonClicks());
        }
        
        public async Task<IActionResult> ButtonClick()
        {
            await _buttonClicks.IncrementButtonClicks();

            return RedirectToAction("Index");
        }
    }
}