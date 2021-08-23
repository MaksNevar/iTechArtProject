using System.Linq;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Foundation;
using iTechArt.SurveysSite.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.SurveysSite.WebApp.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
        private readonly UserManagementService _userManagementService;
        private readonly SurveyService _surveyService;


        public SurveyController(SurveyService surveyService, UserManagementService userManagementService)
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
        public async Task<IActionResult> NewSurvey(SurveyViewModel surveyViewModel, string userName)
        {
            var surveyQuestions = surveyViewModel.Questions.Select(t => new SurveyQuestion
            {
                Description = t.Description,
                QuestionType = t.QuestionType
            }).ToList();

            var survey = new Survey
            {
                Name = surveyViewModel.Name,
                SurveyQuestions = surveyQuestions
            };

            var user = await _userManagementService.GetUserByUsernameAsync(userName);
            await _surveyService.CreateSurveyAsync(user, survey);

            return View();
        }
    }
}
