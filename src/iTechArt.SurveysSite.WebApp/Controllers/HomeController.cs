using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.SurveysSite.Foundation;
using iTechArt.SurveysSite.WebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public sealed class HomeController : Controller
    {
        private readonly ILog _logger;
        private readonly IButtonClicksService _buttonClicksService;


        public HomeController(ILog logger, IButtonClicksService buttonClicksService)
        {
            _logger = logger;

            _buttonClicksService = buttonClicksService;
        }


        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Displaying current clicks number");

            var currentButtonClicksCounter = await _buttonClicksService.GetButtonClicksAsync();
            var buttonClicks = new ButtonClicksCounterViewModel
            {
                Clicks = currentButtonClicksCounter.Clicks
            };

            return View(buttonClicks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ButtonClick()
        {
            await _buttonClicksService.IncrementButtonClicksAsync();

            return RedirectToAction("Index");
        }
    }
}