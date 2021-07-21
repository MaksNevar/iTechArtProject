using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories;

namespace iTechArt.SurveysSite.Foundation
{
    public class ButtonClicksService : IButtonClicksService
    {
        private readonly IButtonClickUnitOfWork _unitOfWork;

        public ButtonClicksService(IButtonClickUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _unitOfWork.Create(new ButtonClicksCounter());
            _unitOfWork.SaveAsync();
        }

        public async Task IncrementButtonClicks()
        {
            var currentClicksCounter = await
                GetCurrentButtonClicks();

            currentClicksCounter.Clicks++;
            _unitOfWork.Update(currentClicksCounter);

            await _unitOfWork.SaveAsync();
        }

        public async Task<ButtonClicksCounter> GetCurrentButtonClicks()
        {
            return await _unitOfWork.GetByIdAsync(1);
        }
    }
}