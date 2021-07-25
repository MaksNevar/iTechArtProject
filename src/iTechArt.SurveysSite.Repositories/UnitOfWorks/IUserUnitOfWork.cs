using iTechArt.Repositories.UnitOfWork;
using iTechArt.SurveysSite.Repositories.Repositories;

namespace iTechArt.SurveysSite.Repositories.UnitOfWorks
{
    public interface IUserUnitOfWork : IUnitOfWork
    {
        public UserRepository UserRepository { get; }
    }
}