using iTechArt.Repositories.UnitOfWork;
using iTechArt.SurveysSite.Repositories.Repositories;

namespace iTechArt.SurveysSite.Repositories.UnitOfWorks
{
    public interface ISurveysSiteUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IRoleRepository RoleRepository { get; }

        ISurveyRepository SurveyRepository { get; }
    }
}