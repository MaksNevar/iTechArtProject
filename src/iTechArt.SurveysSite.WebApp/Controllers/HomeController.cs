using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.SurveysSite.Foundation;
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

            return View(await _buttonClicksService.GetButtonClicksAsync());
        }

        public async Task<IActionResult> ButtonClick()
        {
            await _buttonClicksService.IncrementButtonClicksAsync();

            return RedirectToAction("Index");
        }
    }
}