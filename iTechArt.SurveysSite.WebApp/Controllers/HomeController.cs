using iTechArt.SurveysSite.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using iTechArt.Common;
using System.IO;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(@"..\iTechArt\Common\logs\HomeControllerLogger.txt");
            _logger = loggerFactory.CreateLogger("Logger");
        }

        public string Index()
        {
            _logger.LogInformation($"Method saying Hello, User started working at {DateTime.Now:HH:mm:ss}");
            return "Hello, User";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
