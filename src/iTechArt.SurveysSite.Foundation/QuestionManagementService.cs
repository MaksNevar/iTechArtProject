using System.Collections.Generic;
using System.Linq;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;

namespace iTechArt.SurveysSite.Foundation
{
    public class QuestionManagementService : IQuestionManagementService
    {
        private readonly ISurveysSiteUnitOfWork _unitOfWork;


        public QuestionManagementService(ISurveysSiteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void UpdateQuestions(Survey fromSurvey, Survey survey)
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