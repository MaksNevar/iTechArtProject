using iTechArt.Common;

namespace iTechArt.SurveysSite.Repositories
{
    public interface IButtonClickUnitOfWork : IUnitOfWork
    {
        public ButtonClickRepository Repository { get; }
    }
}