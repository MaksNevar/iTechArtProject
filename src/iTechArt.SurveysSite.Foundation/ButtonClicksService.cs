using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;

namespace iTechArt.SurveysSite.Foundation
{
    public class ButtonClicksService : IButtonClicksService
    {
        private readonly IButtonClickUnitOfWork _unitOfWork;


        public ButtonClicksService(IButtonClickUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task IncrementButtonClicksAsync()
        {
            var currentClicksCounter = await GetButtonClicksAsync();

            currentClicksCounter.Clicks++;
            _unitOfWork.ButtonClickRepository.Update(currentClicksCounter);

            await _unitOfWork.SaveAsync();
        }

        public async Task<ButtonClicksCounter> GetButtonClicksAsync()
        {
            return await _unitOfWork.ButtonClickRepository.GetButtonClicksAsync();
        }
    }
}