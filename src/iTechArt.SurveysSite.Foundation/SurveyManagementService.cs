using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;

namespace iTechArt.SurveysSite.Foundation
{
    public class SurveyManagementService : ISurveyManagementService
    {
        private readonly ISurveysSiteUnitOfWork _unitOfWork;
        private readonly ILog _logger;


        public SurveyManagementService(ISurveysSiteUnitOfWork unitOfWork, ILog logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        public async Task CreateSurveyAsync(Survey survey)
        {
            _unitOfWork.SurveyRepository.Create(survey);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"The survey {survey.Title} created by {survey.Owner.UserName} on {survey.ChangeDate:MM/dd/yyyy}");
        }

        public async Task<IReadOnlyCollection<Survey>> GetAllUserSurveysAsync(int userId)
        {
            var surveys = await _unitOfWork.SurveyRepository.GetAllUserSurveysAsync(userId);

            return surveys;
        }

        public async Task<Survey> GetByIdAsync(int id)
        {
            var survey = await _unitOfWork.SurveyRepository.GetByIdAsync(id);

            if (survey == null)
            {
                throw new ArgumentNullException(nameof(survey), "Survey does not exist");
            }

            return survey;
        }

        public async Task DeleteSurveyAsync(Survey survey)
        {
            _unitOfWork.SurveyRepository.Delete(survey);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateSurveyAsync(Survey fromSurvey, Survey survey)
        {
            UpdateQuestions(fromSurvey, survey);
            fromSurvey.Title = survey.Title;
            fromSurvey.ChangeDate = DateTime.Now;
            await _unitOfWork.SaveAsync();
        }


        private void UpdateQuestions(Survey fromSurvey, Survey survey)
        {
            var questionsToAdd = new List<Question>();

            foreach (var question in survey.Questions)
            {
                var existingQuestion = fromSurvey.Questions
                    .SingleOrDefault(q => q.Id == question.Id);

                if (existingQuestion == null)
                {
                    questionsToAdd.Add(question);
                }
                else
                {
                    existingQuestion.Title = question.Title;
                    _unitOfWork.GetRepository<Question>().Update(existingQuestion);
                }
            }

            foreach (var question in fromSurvey.Questions)
            {
                if (survey.Questions.All(q => q.Id != question.Id))
                {
                    _unitOfWork.GetRepository<Question>().Delete(question);
                }
            }

            fromSurvey.Questions.AddRange(questionsToAdd);
        }
    }
}