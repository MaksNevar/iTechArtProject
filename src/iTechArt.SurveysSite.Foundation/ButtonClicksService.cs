using System.Linq;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories;

namespace iTechArt.SurveysSite.Foundation
{
    public class ButtonClicksService : IButtonClicksService
    {
        private readonly IButtonClickUnitOfWork _unitOfWork;
        private static bool _instanceAdded;


        static ButtonClicksService()
        {
            _instanceAdded = false;
        }

        public ButtonClicksService(IButtonClickUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            if (!_instanceAdded)
            {
                _unitOfWork.Repository.Create(new ButtonClicksCounter());
                _unitOfWork.SaveAsync();
                _instanceAdded = true;
            }
        }


        public async Task IncrementButtonClicks()
        {
            var currentClicksCounter = await
                GetCurrentButtonClicks();

            currentClicksCounter.Clicks++;
            _unitOfWork.Repository.Update(currentClicksCounter);

            await _unitOfWork.SaveAsync();
        }

        public async Task<ButtonClicksCounter> GetCurrentButtonClicks()
        {
            return (await _unitOfWork.Repository.GetAllAsync()).FirstOrDefault();
        }
    }
}