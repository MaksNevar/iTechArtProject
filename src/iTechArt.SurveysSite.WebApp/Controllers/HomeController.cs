using System;
using System.Linq;
using iTechArt.Common;
using iTechArt.SurveysSite.Repositories;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    public sealed class HomeController : Controller
    {
        private readonly ILog _logger;
        private readonly IUnitOfWork<ButtonClicksCounterContext> _unitOfWork;
        private ButtonClicksCounter _currentClicks;


        public HomeController(ILog logger, IUnitOfWork<ButtonClicksCounterContext> unitOfWork)
        {
            _logger = logger;

            _unitOfWork = unitOfWork;

            //_currentClicks = new ButtonClicksCounter();
            //_unitOfWork = new UnitOfWork<ButtonClicksCounterContext>(dbContext, _logger);

            //if (_unitOfWork.Repository.GetById(1) == null)
            //{
            //    _unitOfWork.Repository.Create(new ButtonClicksCounter() {Clicks = 0});
            //    _unitOfWork.Save();
            //}

            //_currentClicks = _unitOfWork.Repository.GetById(1);

            _unitOfWork.GetRepository<ButtonClicksCounter>().Create(new ButtonClicksCounter());
            _unitOfWork.SaveAsync();
        }
        public IActionResult Index()
        {
            _logger.Log(LogLevel.Information, new Exception(),"Displaying current clicks number");

            return View(_unitOfWork.GetRepository<ButtonClicksCounter>().GetAllAsync().Result.FirstOrDefault());
        }

        public IActionResult ButtonClick(string clickMeButton)
        {

            var temp = _unitOfWork.GetRepository<ButtonClicksCounter>().GetAllAsync();
            _currentClicks = temp.Result.FirstOrDefault();
            _currentClicks.Clicks++;
            _unitOfWork.GetRepository<ButtonClicksCounter>().Update(_currentClicks);
            _unitOfWork.SaveAsync();

            return View("Index", _currentClicks);
        }
    }
}