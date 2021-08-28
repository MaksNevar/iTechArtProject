using System;
using System.Linq;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Foundation;
using iTechArt.SurveysSite.WebApp.Helpers;
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
        public IActionResult DisplayMySurveys()
        {
            var userId = User.GetId();
            var surveys = await _surveyService.GetAllUserSurveysAsync(userId);
            var surveyViewModel = surveys.Select(survey => new SurveyViewModel
            {
                Id = survey.Id,
                Title = survey.Title,
                ChangeDate = survey.ChangeDate
            }).ToList();

            return View(surveyViewModel);
        }

        [HttpGet]
        public IActionResult CreateNewSurvey()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNewSurvey(SurveyViewModel surveyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(surveyViewModel);
            }

            var userId = User.GetId();
            var user = await _userManagementService.GetUserByIdAsync(userId);
            var survey = new Survey
            {
                Title = surveyViewModel.Title,
                ChangeDate = DateTime.Now,
                Owner = user
            };

            await _surveyService.CreateSurveyAsync(survey);

            ViewBag.Message = "Survey created successfully";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            var survey = await _surveyService.GetByIdAsync(id);
            await _surveyService.DeleteSurveyAsync(survey);

            return RedirectToAction("MySurveys");
        }
    }
}
