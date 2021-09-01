using System;
using System.Collections.Generic;
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
        private static SurveyViewModel _survey;

        private readonly IUserManagementService _userManagementService;
        private readonly ISurveyManagementService _surveyService;


        public SurveyController(ISurveyManagementService surveyService, IUserManagementService userManagementService)
        {
            _surveyService = surveyService;
            _userManagementService = userManagementService;
        }


        [HttpGet]
        public async Task<IActionResult> DisplayAll()
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
            _survey = new SurveyViewModel
            {
                Questions = new List<SurveyQuestionViewModel>()
            };

            return View(_survey);
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
            var surveyQuestions = surveyViewModel.Questions.Select(t => new SurveyQuestion
            {
                Title = t.Title,
                QuestionType = t.QuestionType
            }).ToList();

            var survey = new Survey
            {
                Title = surveyViewModel.Title,
                ChangeDate = DateTime.Now,
                Owner = user,
                Questions = surveyQuestions
            };

            await _surveyService.CreateSurveyAsync(survey);

            ViewBag.Message = "Survey created successfully";

            return View(surveyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var survey = await _surveyService.GetByIdAsync(id);
            await _surveyService.DeleteSurveyAsync(survey);

            return RedirectToAction("DisplayAll");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var survey = await _surveyService.GetByIdAsync(id);
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

            var userId = User.GetId();
            var user = await _userManagementService.GetUserByIdAsync(userId);

            var survey = new Survey
            {
                Id = surveyViewModel.Id,
                ChangeDate = DateTime.Now,
                Owner = user,
                Title = surveyViewModel.Title
            };

            await _surveyService.UpdateSurveyAsync(survey);

            ViewBag.Message = "Survey edited successfully";

            return View(surveyViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddQuestion(string type)
        {
            if (type == "closed")
            {
                var closedQuestion = new SurveyQuestionViewModel
                {
                    QuestionType = QuestionType.Closed
                };
                _survey.Questions.Add(closedQuestion);
            }
            else
            {
                var openEndedQuestion = new SurveyQuestionViewModel
                {
                    QuestionType = QuestionType.OpenEnded
                };
                _survey.Questions.Add(openEndedQuestion);
            }

            return View("CreateNewSurvey", _survey);
        }
    }
}