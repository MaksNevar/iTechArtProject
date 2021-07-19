using System.Linq;
using iTechArt.Common;
using iTechArt.SurveysSite.Repositories;

namespace iTechArt.SurveysSite.Foundation
{
    public class ButtonClicksLogic
    {
        private readonly IUnitOfWork<ButtonClicksCounterContext> _unitOfWork;

        public ButtonClicksLogic(IUnitOfWork<ButtonClicksCounterContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _unitOfWork.GetRepository<ButtonClicksCounter>().Create(new ButtonClicksCounter());
            _unitOfWork.SaveAsync();
        }

        public void IncrementButtonClicks()
        {
            var currentClicksCounter =
                GetCurrentButtonClicks();

            currentClicksCounter.Clicks++;
            _unitOfWork.GetRepository<ButtonClicksCounter>().Update(currentClicksCounter);
            _unitOfWork.SaveAsync();
        }

        public ButtonClicksCounter GetCurrentButtonClicks()
        {
            return _unitOfWork.GetRepository<ButtonClicksCounter>().GetAllAsync().Result.FirstOrDefault();
        }
    }
}