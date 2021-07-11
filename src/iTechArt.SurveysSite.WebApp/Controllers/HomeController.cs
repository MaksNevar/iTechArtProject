using iTechArt.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public static int ClicksNumber { get; set; }
        public HomeController(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(@"..\iTechArt\Common\logs\HomeControllerLogger.txt");
            _logger = loggerFactory.CreateLogger("Logger");
            ClicksNumber = 0;
            
        }
        public IActionResult Index()
        {
            _logger.LogInformation($"Method saying Hello, User started working at {System.DateTime.Now:HH:mm:ss}");
            ViewData["clicks"] = ClicksNumber;
            return View();
        }

        public IActionResult ButtonClick(string clickMeButton)
        {
            ViewData["clicks"] = ++ClicksNumber;
            return View("Index");
        }
    }
}
