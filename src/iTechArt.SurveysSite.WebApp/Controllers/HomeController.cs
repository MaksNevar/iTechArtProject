using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public sealed class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly UnitOfWork _unitOfWork;
        private readonly ButtonClicksCounter _currentClicks;


        public HomeController(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(@"..\iTechArt\Common\logs\logs.txt");
            _logger = loggerFactory.CreateLogger("Logger");

            var options = new DbContextOptionsBuilder<ButtonClicksCounterContext>().UseInMemoryDatabase("TestDb").Options;
            var dbContext = new ButtonClicksCounterContext(options);
            _unitOfWork = new UnitOfWork(dbContext, new Repository<ButtonClicksCounter>(dbContext, _logger));

            _unitOfWork.Repository.Create(new ButtonClicksCounter() { Clicks = 0 });
            _unitOfWork.Save();
            _currentClicks = _unitOfWork.Repository.GetOne(1);
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Displaying current clicks number");

            return View(_currentClicks);
        }

        public IActionResult ButtonClick(string clickMeButton)
        {
            _currentClicks.Clicks++;
            _unitOfWork.Repository.Update(_currentClicks);
            _unitOfWork.Save();

            return View("Index", _currentClicks);
        }
    }
}