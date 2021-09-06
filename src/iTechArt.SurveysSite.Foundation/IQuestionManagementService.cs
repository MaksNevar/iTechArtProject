using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Foundation
{
    public interface IQuestionManagementService
    {
        public void UpdateQuestions(Survey fromSurvey, Survey survey);
    }
}