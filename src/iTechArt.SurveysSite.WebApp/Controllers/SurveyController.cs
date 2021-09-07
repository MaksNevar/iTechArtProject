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
        public async Task<IActionResult> Index()
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SurveyViewModel surveyViewModel)
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
        public async Task<IActionResult> Delete(int id)
        {
            var survey = await _surveyService.GetByIdAsync(id);

            if (!IsUserValid(survey.Owner.Id))
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            await _surveyService.DeleteSurveyAsync(survey);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var survey = await _surveyService.GetByIdAsync(id);

            if (!IsUserValid(survey.Owner.Id))
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            var surveyViewModel = new SurveyViewModel
            {
                Id = survey.Id,
                Title = survey.Title
            };

            return View(surveyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SurveyViewModel surveyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(surveyViewModel);
            }

            var survey = await ConvertToSurveyAsync(surveyViewModel);

            if (!IsUserValid(survey.Owner.Id))
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            var fromSurvey = await _surveyService.GetByIdAsync(surveyViewModel.Id);
            await _surveyService.UpdateSurveyAsync(fromSurvey, survey);

            ViewBag.Message = "Survey edited successfully";

            return View(surveyViewModel);
        }


        private async Task<Survey> ConvertToSurveyAsync(SurveyViewModel surveyViewModel)
        {
            var survey = await _surveyService.GetByIdAsync(surveyViewModel.Id);
            survey.Title = surveyViewModel.Title;

            return survey;
        }

        private bool IsUserValid(int id)
        {
            var userId = User.GetId();

            return userId == id;
        }
    }
}