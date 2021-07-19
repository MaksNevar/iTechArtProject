using System;
using System.Linq;
using iTechArt.Common;
using iTechArt.SurveysSite.Foundation;
using iTechArt.SurveysSite.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public sealed class HomeController : Controller
    {
        private readonly ILog _logger;

        private readonly ButtonClicksLogic _buttonClicks;


        public HomeController(ILog logger, ButtonClicksLogic buttonClicks)
        {
            _logger = logger;

            _buttonClicks = buttonClicks;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.Log(LogLevel.Information, "Displaying current clicks number");

            return View(_buttonClicks.GetCurrentButtonClicks());
        }
        
        public IActionResult ButtonClick()
        {
            _buttonClicks.IncrementButtonClicks();

            return RedirectToAction("Index");
        }
    }
}