using System.Linq;
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

            if (!_entityAdded)
            {
                _unitOfWork.ButtonClickRepository.Create(new ButtonClicksCounter());
                _unitOfWork.SaveAsync();

                _entityAdded = true;
            }
            
        }


        public async Task IncrementButtonClicksAsync()
        {
            var currentClicksCounter = await
                GetCurrentButtonClicksAsync();

            currentClicksCounter.Clicks++;
            _unitOfWork.ButtonClickRepository.Update(currentClicksCounter);

            await _unitOfWork.SaveAsync();
        }

        public async Task<ButtonClicksCounter> GetCurrentButtonClicksAsync()
        {
            return (await _unitOfWork.ButtonClickRepository.GetAllAsync()).FirstOrDefault();
        }
    }
}