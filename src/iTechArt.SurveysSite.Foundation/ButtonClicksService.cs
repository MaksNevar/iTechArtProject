using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;

namespace iTechArt.SurveysSite.Foundation
{
    public class ButtonClicksService : IButtonClicksService
    {
        private static bool _entityAdded;
        private readonly IButtonClickUnitOfWork _unitOfWork;


        static ButtonClicksService()
        {
            _entityAdded = false;
        }

        public ButtonClicksService(IButtonClickUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task IncrementButtonClicksAsync()
        {
            var currentClicksCounter = await
                GetButtonClicksAsync();

            currentClicksCounter.Clicks++;
            _unitOfWork.ButtonClickRepository.Update(currentClicksCounter);

            await _unitOfWork.SaveAsync();
        }

        public async Task<ButtonClicksCounter> GetButtonClicksAsync()
        {
            if (!_entityAdded)
            {
                _unitOfWork.ButtonClickRepository.Create(new ButtonClicksCounter());
                await _unitOfWork.SaveAsync();

                _entityAdded = true;
            }

            return await _unitOfWork.ButtonClickRepository.GetButtonClicksAsync();
        }
    }
}