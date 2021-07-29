using iTechArt.Repositories.Repository;
using iTechArt.Repositories.UnitOfWork;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Repositories.UnitOfWorks
{
    public interface ISurveysSiteUnitOfWork : IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
    }
}