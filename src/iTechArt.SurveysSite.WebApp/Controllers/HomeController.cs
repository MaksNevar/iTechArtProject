using iTechArt.Common;
using iTechArt.SurveysSite.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public sealed class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly UnitOfWork<ButtonClicksCounterContext> _unitOfWork;
        private readonly ButtonClicksCounter _currentClicks;


        public HomeController(ILogger logger, ButtonClicksCounterContext dbContext)
        {
            _logger = logger;

            //_unitOfWork = new UnitOfWork<ButtonClicksCounterContext>(dbContext, _logger);

            //if (_unitOfWork.Repository.GetById(1) == null)
            //{
            //    _unitOfWork.Repository.Create(new ButtonClicksCounter() {Clicks = 0});
            //    _unitOfWork.Save();
            //}

            //_currentClicks = _unitOfWork.Repository.GetById(1);
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Displaying current clicks number");

            return View(_currentClicks);
        }

        public IActionResult ButtonClick(string clickMeButton)
        {
            _currentClicks.Clicks++;
            //_unitOfWork.Repository.Update(_currentClicks);
            //_unitOfWork.Save();

            return View("Index", _currentClicks);
        }
    }
}