using System;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Foundation;
using iTechArt.SurveysSite.Repositories;
using iTechArt.SurveysSite.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
        private readonly IUserManagementService _userManagementService;
        private readonly ISurveyManagementService _surveyService;


        public SurveyController(ISurveyManagementService surveyService, IUserManagementService userManagementService)
        {
            _surveyService = surveyService;
            _userManagementService = userManagementService;
        }


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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewSurvey(SurveyViewModel surveyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(surveyViewModel);
            }

            var userId = User.GetId();
            var user = await _userManagementService.GetUserByIdAsync(userId);
            var survey = new Survey
            {
                Title = surveyViewModel.Name,
                ChangeDate = DateTime.Now,
                Owner = user
            };

            await _surveyService.CreateSurveyAsync(survey);

            ViewBag.Message = "Survey created successfully";

            return View();
        }
    }
}
